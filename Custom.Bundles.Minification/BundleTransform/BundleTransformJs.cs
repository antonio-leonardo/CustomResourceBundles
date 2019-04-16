using System.Web.Optimization;

using Custom.Bundles.Minification.Core;

namespace Custom.Bundles.Minification.BundleTransform
{
    /// <summary>
    /// Classe derivada com especialização com tipo de conteúdo HTTP para arquivos de Script JS
    /// </summary>
    public sealed class BundleTransformJs : BundleTransformBase
    {
        /// <summary>
        /// Construtor utilizando da base a escolha do tipo de arquivo para JS
        /// </summary>
        public BundleTransformJs() : base(FileTypeToMinifie.JS)
        {
        }

        /// <summary>
        /// Transforma o conteúdo de arquivos JavaScript sobre o objeto System.Web.Optimization.BundleResponse
        /// </summary>
        /// <param name="context">O context do Bundle</param>
        /// <param name="response">Response do bundle</param>
        public override void Process(BundleContext context, BundleResponse response)
        {
            base.Process(context, response);
            response.ContentType = "text/javascript";
        }
    }
}