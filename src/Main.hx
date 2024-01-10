package;

import lime.utils.Float64Array;
import lime.graphics.WebGLRenderContext;
import frambos.core.Assets;
import frambos.core.Assets.Texture;
import frambos.ecs.Block;
import frambos.ecs.BlockTree;
import markisa.bootloader.Boot;
import lime.app.Application;
import lime.graphics.opengl.GLBuffer;
import lime.graphics.opengl.GLProgram;
import lime.graphics.opengl.GLTexture;
import lime.graphics.opengl.GLUniformLocation;
import lime.graphics.RenderContext;

class Main extends Application {
	var glBuffer: GLBuffer;
	var glMatrixUniform: GLUniformLocation;
	var glProgram: GLProgram;
	var glTexture: GLTexture;
	var glTextureAttribute: Int;
	var glVertexAttribute: Int;
	var image: Texture;
	var timeToSetupOpenGeeEl = true;
	var positionsAndShit = new Float64Array(6, null, [
		-0.5, -0.5,
		 0.0,  0.5,
		 0.5, -0.5
	]);
	
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
			case OPENGL, OPENGLES:
				var gl = context.webgl;
				trace("time to render lmao");
				
				if (preloader.complete) {
					trace("shit has been preloaded");
					if (timeToSetupOpenGeeEl) {
						trace("setting up opengl");
						timeToSetupOpenGl(gl);
						trace("opengl has been setup");

						timeToSetupOpenGeeEl = false;
						trace("setup is done");
					} else {
						trace("time to render bullshit");
						renderStuffAndStuff(gl, context);
						trace("bullshit has been rendered");
					}
				} else {
					trace("no shit preloaded :(");
				}

				trace("ok done");
			
			default:
		}
	}

	function timeToSetupOpenGl(gl: WebGLRenderContext) {
		// awesome opengl setup bullshit
		glBuffer = gl.createBuffer();
		
		// give opengl the triangle
		trace("buffering data");
		gl.bufferData(gl.ARRAY_BUFFER, positionsAndShit, gl.STATIC_DRAW);

		trace("enabling vertex attribute array");
		gl.enableVertexAttribArray(0);
		// tell opengl what does our awesome array mean
		trace("setting vertex attribute pointer");
		gl.vertexAttribPointer(0, 2, gl.FLOAT, false, 8, 0);

		// quite the mouthful
		var awesomeShader = GLProgram.fromSources(gl, Assets.loadText("res://assets/testVertexShader.vert"),
													  Assets.loadText("res://assets/testFragmentShader.frag"));
		
		gl.useProgram(awesomeShader);
	}

	function renderStuffAndStuff(gl: WebGLRenderContext, context: RenderContext) {
		var r = ((context.attributes.background >> 16) & 0xFF) / 0xFF;
		var g = ((context.attributes.background >> 8) & 0xFF) / 0xFF;
		var b = (context.attributes.background & 0xFF) / 0xFF;
		var a = ((context.attributes.background >> 24) & 0xFF) / 0xFF;

		gl.viewport(0, 0, window.width, window.height);
		gl.clearColor(r, g, b, a);
		gl.clear(gl.COLOR_BUFFER_BIT);
		
		gl.bindBuffer(gl.ARRAY_BUFFER, glBuffer);

		trace("drawing arrays");
		gl.drawArrays(gl.TRIANGLES, 0, 3);
	}
}