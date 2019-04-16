using System;
using System.Web;
using System.Text;
using System.Web.Optimization;

using Custom.Bundles.Minification.Core;

namespace Custom.Bundles.Minification.BundleTransform
{
    /// <summary>
    /// Especialização da transformação dos Bundles para adequar-se a inclusão de arquivos inclusos no Resources
    /// </summary>
    public class BundleTransformBase : IBundleTransform
    {
        /// <summary>
        /// Escolha da extensão de arquivo que será Minificado
        /// </summary>
        private static FileTypeToMinifie _fileToMinifie;

        /// <summary>
        /// Construtor para escolha 
        /// </summary>
        /// <param name="fileToMinifie">Escolha da extensão de arquivo que será Minificado</param>
        public BundleTransformBase(FileTypeToMinifie fileToMinifie)
        {
            _fileToMinifie = fileToMinifie;
        }

        /// <summary>
        /// Transforma o conteúdo de arquivos CSS sobre o objeto System.Web.Optimization.BundleResponse
        /// </summary>
        /// <param name="context">O context do Bundle</param>
        /// <param name="response">Response do bundle</param>
        public virtual void Process(BundleContext context, BundleResponse response)
        {
            StringBuilder fileContentSB = new StringBuilder();
            (new CustomResourceOperations(_fileToMinifie)).IterateOnResourceRepository(ref fileContentSB);            
            context.UseServerCache = false;
            response.Cacheability = HttpCacheability.NoCache;
            response.Content = DateTime.Now.ToString();
            response.Content = fileContentSB.ToString();
        }
    }
}