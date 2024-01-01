namespace frambos.android;
using System.Diagnostics;
using Android.App;
using Android.Opengl;
using Android.Runtime;
using Silk.NET.OpenGL;
using Silk.NET.Windowing;
using Silk.NET.Windowing.Sdl.Android;

/// <summary>
/// Simple demo on how to use Silk on Android.
/// The code used is mostly identical to the one on OpenGL Tutorial 1.4 - Textures.
/// </summary>
[Activity(Label = "@string/app_name", MainLauncher = true)]
public class MainActivity : GLSurfaceView {
    // Instead of IWindow, we use IView. 
    // IWindow inherits IView, so you can also use this with your desktop code.
    private static IView view;
    private static GL Gl;

    private static readonly uint[] Indices = {
        0, 1, 3,
        1, 2, 3
    };

    protected MainActivity(nint javaReference, JniHandleOwnership transfer) : base(javaReference, transfer) {
        // Included assets should be loaded with the help of Android.Content.Res.AssetManager.
        // The included example shaders and texture have build action of "AndroidAsset".
        //FileManager.AssetManager = Assets;

        ViewOptions options = ViewOptions.Default;
        // We need to tell Silk to use OpenGLES
        // Version 3.0 is supported by >90% of devices currently in use.
        // https://developer.android.com/about/dashboards#OpenGL
        options.API = new GraphicsAPI(ContextAPI.OpenGLES, ContextProfile.Compatability, ContextFlags.Default, new APIVersion(2, 0));
        view = Window.GetView(options); // note also GetView, instead of Window.Create.

        view.Load += OnLoad;
        view.Render += OnRender;
        view.Closing += OnClose;

        view.Run();

        view.Dispose();
    }

    private static unsafe void OnLoad() {
        Gl = GL.GetApi(view);
    }

    private static unsafe void OnRender(double obj) {
        Gl.Clear((uint)ClearBufferMask.ColorBufferBit);

        Gl.DrawElements(PrimitiveType.Triangles, (uint)Indices.Length, DrawElementsType.UnsignedInt, null);
    }

    private static void OnClose() {
    }
}