package;

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
	var awesomeData = new ArrayBufferView(null, TypedArrayType.Float64);
	
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
				
				if (timeToSetupOpenGeeEl && preloader.complete) {
					timeToSetupOpenGl(gl);
					timeToSetupOpenGeeEl = false;
				}
			
			default:
		}
	}

	public function timeToSetupOpenGl(gl: WebGLRenderContext) {
		glBuffer = gl.createBuffer();
		gl.bindBuffer(gl.ARRAY_BUFFER, glBuffer);
		gl.bufferData(gl.ARRAY_BUFFER, awesomeData);
	}
}