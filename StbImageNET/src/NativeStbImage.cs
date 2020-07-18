using System;
using System.IO;
using System.Runtime.InteropServices;

namespace StbImageNET
{
	public static unsafe class NativeStbImage
	{
		public const string DLL_NAME = "stb_image.dll";
		
		static NativeStbImage()
		{
			NativeLibrary.SetDllImportResolver(typeof(NativeStbImage).Assembly, (name, assembly, path) => {
				if (name != DLL_NAME)
					return IntPtr.Zero;
				return Environment.Is64BitProcess ?
					NativeLibrary.Load("stb_image_win-x64.dll", assembly, path) :
					NativeLibrary.Load("stb_image_win-x86.dll", assembly, path);
			});
		}

		[DllImport(DLL_NAME)]
		public static extern byte* stbi_load_from_memory(byte* buffer, int len , int* x, int* y, int* channels_in_file, int desired_channels);

		[DllImport(DLL_NAME)]
		public static extern byte* stbi_load(byte* filename, int* x, int* y, int* channels_in_file, int desired_channels);

		[DllImport(DLL_NAME)]
		public static extern byte* stbi_load_gif_from_memory(byte* buffer, int len, int* *delays, int* x, int* y, int* z, int* comp, int req_comp);

		[DllImport(DLL_NAME)]
		public static extern ushort* stbi_load_16_from_memory(byte* buffer, int len, int* x, int* y, int* channels_in_file, int desired_channels);

		[DllImport(DLL_NAME)]
		public static extern ushort* stbi_load_16(byte* filename, int* x, int* y, int* channels_in_file, int desired_channels);

		[DllImport(DLL_NAME)]
		public static extern float* stbi_loadf_from_memory(byte* buffer, int len, int* x, int* y, int* channels_in_file, int desired_channels);

		[DllImport(DLL_NAME)]
		public static extern float* stbi_loadf(byte* filename, int* x, int* y, int* channels_in_file, int desired_channels);

		[DllImport(DLL_NAME)]
		public static extern void stbi_hdr_to_ldr_gamma(float gamma);

		[DllImport(DLL_NAME)]
		public static extern void stbi_hdr_to_ldr_scale(float scale);

		[DllImport(DLL_NAME)]
		public static extern void stbi_ldr_to_hdr_gamma(float gamma);

		[DllImport(DLL_NAME)]
		public static extern void stbi_ldr_to_hdr_scale(float scale);

		[DllImport(DLL_NAME)]
		public static extern int stbi_is_hdr_from_memory(byte* buffer, int len);

		[DllImport(DLL_NAME)]
		public static extern int stbi_is_hdr(byte* filename);

		[DllImport(DLL_NAME)]
		public static extern byte* stbi_failure_reason();

		[DllImport(DLL_NAME)]
		public static extern void stbi_image_free(void* retval_from_stbi_load);

		[DllImport(DLL_NAME)]
		public static extern int stbi_info_from_memory(byte* buffer, int len, int* x, int* y, int* comp);

		[DllImport(DLL_NAME)]
		public static extern int stbi_is_16_bit_from_memory(byte* buffer, int len);

		[DllImport(DLL_NAME)]
		public static extern int stbi_info(byte* filename, int* x, int* y, int* comp);

		[DllImport(DLL_NAME)]
		public static extern int stbi_is_16_bit(byte* filename);

		[DllImport(DLL_NAME)]
		public static extern void stbi_set_unpremultiply_on_load(int flag_true_if_should_unpremultiply);

		[DllImport(DLL_NAME)]
		public static extern void stbi_convert_iphone_png_to_rgb(int flag_true_if_should_convert);

		[DllImport(DLL_NAME)]
		public static extern void stbi_set_flip_vertically_on_load(int flag_true_if_should_flip);
	}
}