using System;
using System.Runtime.InteropServices;
using System.Text;

namespace StbImageNET
{
	public unsafe class StbImage
	{
		public static byte* Load(string fileName, out int x, out int y, out Components comp, Components desiredChannels = 0)
		{
			int nx;
			int ny;
			int ncomp;

			byte* res;
			
			fixed (byte* ptr = Encoding.UTF8.GetBytes(fileName + '\0'))
			{
				res = NativeStbImage.stbi_load(ptr, &nx, &ny, &ncomp, (int)desiredChannels);
			}

			x = nx;
			y = ny;
			comp = (Components)ncomp;

			return res;
		}
		
		public static ushort* Load16(string fileName, out int x, out int y, out Components comp, Components desiredChannels = 0)
		{
			int nx;
			int ny;
			int ncomp;

			ushort* res;
			
			fixed (byte* ptr = Encoding.UTF8.GetBytes(fileName + '\0'))
			{
				res = NativeStbImage.stbi_load_16(ptr, &nx, &ny, &ncomp, (int)desiredChannels);
			}

			x = nx;
			y = ny;
			comp = (Components)ncomp;

			return res;
		}
		
		public static float* Loadf(string fileName, out int x, out int y, out Components comp, Components desiredChannels = 0)
		{
			int nx;
			int ny;
			int ncomp;

			float* res;
			
			fixed (byte* ptr = Encoding.UTF8.GetBytes(fileName + '\0'))
			{
				res = NativeStbImage.stbi_loadf(ptr, &nx, &ny, &ncomp, (int)desiredChannels);
			}

			x = nx;
			y = ny;
			comp = (Components)ncomp;

			return res;
		}

		public static void HdrToLdrGamma(float gamma)
		{
			NativeStbImage.stbi_hdr_to_ldr_gamma(gamma);
		}
		
		public static void HdrToLdrScale(float scale)
		{
			NativeStbImage.stbi_hdr_to_ldr_scale(scale);
		}
		
		public static void LdrToHdrGamma(float gamma)
		{
			NativeStbImage.stbi_ldr_to_hdr_gamma(gamma);
		}
		
		public static void LdrToHdrScale(float scale)
		{
			NativeStbImage.stbi_ldr_to_hdr_scale(scale);
		}

		public static bool IsHdr(string fileName)
		{
			bool res;
			
			fixed (byte* ptr = Encoding.UTF8.GetBytes(fileName + '\0'))
			{
				res = NativeStbImage.stbi_is_hdr(ptr) == 1;
			}

			return res;
		}
		
		public static string FailureReason()
		{
			return Marshal.PtrToStringUTF8((IntPtr) NativeStbImage.stbi_failure_reason());
		}
		
		public static void ImageFree(void* image)
		{
			NativeStbImage.stbi_image_free(image);
		}
		
		public static bool Info(string fileName, out int x, out int y, out Components comp)
		{
			int nx;
			int ny;
			int ncomp;

			bool res;
			
			fixed (byte* ptr = Encoding.UTF8.GetBytes(fileName + '\0'))
			{
				res = NativeStbImage.stbi_info(ptr, &nx, &ny, &ncomp) == 1;
			}

			x = nx;
			y = ny;
			comp = (Components)ncomp;

			return res;
		}
		
		public static bool Is16Bit(string fileName)
		{
			bool res;
			
			fixed (byte* ptr = Encoding.UTF8.GetBytes(fileName + '\0'))
			{
				res = NativeStbImage.stbi_is_16_bit(ptr) == 1;
			}

			return res;
		}

		public static void SetUnpremultiplyOnLoad(bool shouldUnpremultiply)
		{
			NativeStbImage.stbi_set_unpremultiply_on_load(shouldUnpremultiply ? 1 : 0);
		}

		public static void ConvertIphonePngToRgb(bool shouldConvert)
		{
			NativeStbImage.stbi_convert_iphone_png_to_rgb(shouldConvert ? 1 : 0);
		}

		public static void SetFlipVerticallyOnLoad(bool shouldFlip)
		{
			NativeStbImage.stbi_set_flip_vertically_on_load(shouldFlip ? 1 : 0);
		}
	}
}