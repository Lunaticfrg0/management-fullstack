namespace Helpers.GlobalFunctions
{
    public class ImageTransformToString
    {
        public static string ImgToString64(byte[] data, string ContentType)
        {
            var result = Convert.ToBase64String(data);
            return String.Format("data:" + ContentType + ";base64,{0}", result);
        }
    }
}
