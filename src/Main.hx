package;

import frambos.core.Assets;
import frambos.core.Assets.Texture;
import frambos.ecs.Block;
import frambos.ecs.BlockTree;
import markisa.bootloader.Boot;
import lime.app.Application;
import lime.graphics.cairo.CairoImageSurface;
import lime.graphics.opengl.GLBuffer;
import lime.graphics.opengl.GLProgram;
import lime.graphics.opengl.GLTexture;
import lime.graphics.opengl.GLUniformLocation;
import lime.graphics.RenderContext;
import lime.math.Matrix4;
import lime.utils.Float32Array;

class Main extends Application {
	var cairoSurface: CairoImageSurface;
	var glBuffer: GLBuffer;
	var glMatrixUniform: GLUniformLocation;
	var glProgram: GLProgram;
	var glTexture: GLTexture;
	var glTextureAttribute: Int;
	var glVertexAttribute: Int;
	var image: Texture;
	
	public function new() {
		super();

		// make it recognize the correct place for putting files
		meta.set("company", "hellory4n");
		meta.set("file", "MarkisaOS");

		// create the block tree
        var root = new Block();
        root.name = "root";
        BlockTree.root = root;

		new Boot();
	}
	
	public override function update(deltaTime: Int) {
		BlockTree.callUpdate(deltaTime / 1000);
	}
	
	public override function render(context: RenderContext) {
		BlockTree.callDraw();
		
		switch (context.type) {			
			case OPENGL, OPENGLES, WEBGL:
				var gl = context.webgl;
				
				if (image == null && preloader.complete) {
					image = Assets.loadTexture("res://assets/icon.png");
					
					var vertexSource = 
						"attribute vec4 aPosition;
						attribute vec2 aTexCoord;
						varying vec2 vTexCoord;
						
						uniform mat4 uMatrix;
						
						void main(void) {
							vTexCoord = aTexCoord;
							gl_Position = uMatrix * aPosition;
						}";
					
					var fragmentSource = 
						#if !desktop
						"precision mediump float;" +
						#end
						"varying vec2 vTexCoord;
						uniform sampler2D uImage0;
						
						void main(void) {
							gl_FragColor = texture2D(uImage0, vTexCoord);
						}";
					
					glProgram = GLProgram.fromSources (gl, vertexSource, fragmentSource);
					gl.useProgram (glProgram);
					
					glVertexAttribute = gl.getAttribLocation (glProgram, "aPosition");
					glTextureAttribute = gl.getAttribLocation (glProgram, "aTexCoord");
					glMatrixUniform = gl.getUniformLocation (glProgram, "uMatrix");
					var imageUniform = gl.getUniformLocation (glProgram, "uImage0");
					
					gl.enableVertexAttribArray (glVertexAttribute);
					gl.enableVertexAttribArray (glTextureAttribute);
					gl.uniform1i (imageUniform, 0);
					
					gl.blendFunc (gl.SRC_ALPHA, gl.ONE_MINUS_SRC_ALPHA);
					gl.enable (gl.BLEND);
					
					var data = [
						image.width, image.height, 0, 1, 1,
						0, image.height, 0, 0, 1,
						image.width, 0, 0, 1, 0,
						0, 0, 0, 0, 0
					];
					
					glBuffer = gl.createBuffer ();
					gl.bindBuffer (gl.ARRAY_BUFFER, glBuffer);
					gl.bufferData (gl.ARRAY_BUFFER, new Float32Array (data), gl.STATIC_DRAW);
					gl.bindBuffer (gl.ARRAY_BUFFER, null);
					
					glTexture = gl.createTexture ();
					gl.bindTexture (gl.TEXTURE_2D, glTexture);
					gl.texParameteri (gl.TEXTURE_2D, gl.TEXTURE_WRAP_S, gl.CLAMP_TO_EDGE);
					gl.texParameteri (gl.TEXTURE_2D, gl.TEXTURE_WRAP_T, gl.CLAMP_TO_EDGE);
					gl.texImage2D (gl.TEXTURE_2D, 0, gl.RGBA, image.buffer.width, image.buffer.height, 0, gl.RGBA, gl.UNSIGNED_BYTE, image.data);
					
					gl.texParameteri (gl.TEXTURE_2D, gl.TEXTURE_MAG_FILTER, gl.LINEAR);
					gl.texParameteri (gl.TEXTURE_2D, gl.TEXTURE_MIN_FILTER, gl.LINEAR);
					gl.bindTexture (gl.TEXTURE_2D, null);
				}
				
				gl.viewport (0, 0, window.width, window.height);
				
				var r = ((context.attributes.background >> 16) & 0xFF) / 0xFF;
				var g = ((context.attributes.background >> 8) & 0xFF) / 0xFF;
				var b = (context.attributes.background & 0xFF) / 0xFF;
				var a = ((context.attributes.background >> 24) & 0xFF) / 0xFF;
				
				gl.clearColor (r, g, b, a);
				gl.clear (gl.COLOR_BUFFER_BIT);
				
				if (image != null) {
					var matrix = new Matrix4 ();
					matrix.createOrtho (0, window.width, window.height, 0, -1000, 1000);
					gl.uniformMatrix4fv (glMatrixUniform, false, matrix);
					
					gl.activeTexture (gl.TEXTURE0);
					gl.bindTexture (gl.TEXTURE_2D, glTexture);
					
					#if desktop
					gl.enable (gl.TEXTURE_2D);
					#end
					
					gl.bindBuffer (gl.ARRAY_BUFFER, glBuffer);
					gl.vertexAttribPointer (glVertexAttribute, 3, gl.FLOAT, false, 5 * Float32Array.BYTES_PER_ELEMENT, 0);
					gl.vertexAttribPointer (glTextureAttribute, 2, gl.FLOAT, false, 5 * Float32Array.BYTES_PER_ELEMENT, 3 * Float32Array.BYTES_PER_ELEMENT);
					
					gl.drawArrays (gl.TRIANGLE_STRIP, 0, 4);
				}
			
			default:
		}
	}
}