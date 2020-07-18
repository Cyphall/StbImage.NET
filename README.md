# StbImage.NET

This library is a wrapper around the stb_image.h library.<br/>
This wrapper is currently only available for Windows 32 & 64 bit.

It consists of 2 classes:

#### NativeStbImage

This class exposes the raw P/Invoke calls to the lib, using raw unsafe pointers.<br/>
All "public" stb_image functions are exposed, except FILE* based ones (obviously, there is no stdio.h in C#) and, for now, callback-based ones.

#### StbImage

This class exposes csharp-ised functions, handling most of the basic C -> C# transition itself.
