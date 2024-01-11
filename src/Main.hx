package;

import frambos.core.Project;
import frambos.core.Signal;
import frambos.graphics.RenderDevice;
import lime.graphics.cairo.CairoImageSurface;
import frambos.core.Assets;
import frambos.core.Assets.Texture;
import frambos.ecs.Block;
import frambos.ecs.BlockTree;
import markisa.bootloader.Boot;
import lime.app.Application;
import lime.graphics.RenderContext;

class Main extends Application {
	public var onEngineSetup = new SignalNoArgs();

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
		onEngineSetup.connect(BlockTree.handleQueuedReadyStuff);
        BlockTree.root = root;

		new Boot();
	}
	
	public override function update(deltaTime: Int) {
		BlockTree.callUpdate(deltaTime / 1000);
	}
	
	public override function render(context: RenderContext) {
		
		
		switch (context.type) {
			case CAIRO:
				var cairo = context.cairo;
				RenderDevice.cairo = cairo;
				
				if (preloader.complete && !Project.engineSetupDone) {
					Project.engineSetupDone = true;
					onEngineSetup.emit();
				}
				
				// clear the screen
				var r = ((context.attributes.background >> 16) & 0xFF) / 0xFF;
				var g = ((context.attributes.background >> 8) & 0xFF) / 0xFF;
				var b = (context.attributes.background & 0xFF) / 0xFF;
				cairo.setSourceRGB(r, g, b);
				cairo.paint();
				
				BlockTree.callDraw();
				
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