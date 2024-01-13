package;

import frambos.ecs.etc.Viewport;
import frambos.core.Project;
import frambos.graphics.RenderDevice;
import lime.graphics.cairo.CairoImageSurface;
import frambos.core.Assets.Texture;
import frambos.ecs.Block;
import frambos.ecs.BlockTree;
import markisa.bootloader.Boot;
import lime.app.Application;
import lime.graphics.RenderContext;

class Main extends Application {
	var image: Texture;
	var cairoSurface: CairoImageSurface;
	
	public function new() {
		super();

		// make it recognize the correct place for putting files
		meta.set("company", "hellory4n");
		meta.set("file", "MarkisaOS");

		// create the block tree
        var root = new Block();
        root.name = "root";
        BlockTree.root = root;
		var rootViewport = root.getPiece(Viewport);

		// setup the screen
		// i am comedy
		/*var ratio = window.width / window.height;
		var width = 720 * ratio;
		Project._width = Math.round(width);
		Project._height = 720;
		root.size = new Vec2(window.width, window.height);
		rootViewport.originalSize = new Vec2(Project._width, Project._height);
		rootViewport.scale = true;*/

		new Boot();
	}
	
	public override function update(deltaTime: Int) {
		if (Project.engineSetupDone) {
			BlockTree.callUpdate(deltaTime / 1000);
		}
	}

	public override function onPreloadComplete() {
		Project.engineSetupDone = true;
		trace("oh boy");

		// handle the blocks that were created before the engine was setup
		for (lol in Block.queuedForReady) {
			trace("just casually handling a piece");
            lol.prepareDraw(lol.block.device);
            lol.ready();
        }
		Block.queuedForReady = [];
		trace("queued pieces are no more");
	}
	
	public override function render(context: RenderContext) {
		switch (context.type) {
			case CAIRO:
				var cairo = context.cairo;
				Viewport.cairo = cairo;
				
				// clear the screen
				cairo.setSourceRGB(0, 0, 0);
				cairo.paint();
				
				if (Project.engineSetupDone) {
					BlockTree.callDraw();
				}
				
				/*if (image != null) {
					image.format = BGRA32;
					image.premultiplied = true;
					
					cairo.setSourceSurface(cairoSurface, 0, 0);
					cairo.paint();
				}*/
			
			default:
		}
	}
}