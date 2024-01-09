package;

import lime.utils.ArrayBuffer;
import lime.utils.Float64Array;
import lime.graphics.OpenGLES3RenderContext;
import lime.utils.ArrayBufferView;
import lime.graphics.WebGLRenderContext;
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
			case OPENGL, OPENGLES, WEBGL:
				var gl = context.gles3;
				
				if (timeToSetupOpenGeeEl && preloader.complete) {
					timeToSetupOpenGl(gl);
					timeToSetupOpenGeeEl = false;
				} else {
					renderStuffAndStuff(gl);
				}
			
			default:
		}
	}

	public function timeToSetupOpenGl(gl: OpenGLES3RenderContext) {
		// awesome opengl setup bullshit
		glBuffer = gl.createBuffer();
		gl.bindBuffer(gl.ARRAY_BUFFER, glBuffer);

		// give opengl the triangle
		gl.bufferData(gl.ARRAY_BUFFER, 6, positionsAndShit, gl.STATIC_DRAW);
	}

	public function renderStuffAndStuff(gl: OpenGLES3RenderContext) {
		gl.drawArrays(gl.TRIANGLES, 0, 3);
	}
}