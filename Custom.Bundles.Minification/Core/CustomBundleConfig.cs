using System.Web.Optimization;

using Custom.Bundles.Minification.BundleTransform;

namespace Custom.Bundles.Minification.Core
{
    /// <summary>
    /// Enumerado para identificar o tipo de arquivo que será consumido e minificado
    /// </summary>
    public enum FileTypeToMinifie
    {
        /// <summary>
        /// Arquivo de Estilos para HTML
        /// </summary>
        CSS,
        /// <summary>
        /// Arquivos com Scripts para HTML
        /// </summary>
        JS,
        /// <summary>
        /// Documento de texto
        /// </summary>
        TXT,
        /// <summary>
        /// Arquivos de Tags customizadas
        /// </summary>
        XML
    }

    /// <summary>
    /// Configuração dos Bundles Padronizados para o Template da  PMS
    /// </summary>
    public sealed class CustomBundleConfig
    {
        /// <summary>
        /// Execução do registro dos Bundles
        /// </summary>
        /// <param name="bundles">Coleção de Bundles</param>
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Clear();

            BundleTransformJs transformJS = new BundleTransformJs();
            Bundle customScriptBundle = new Bundle("~/Bundles/JS", transformJS);
            bundles.Add(customScriptBundle);

            BundleTransformCss transformCSS = new BundleTransformCss();
            Bundle customStyleBundle = new Bundle("~/Bundles/CSS", transformCSS);
            bundles.Add(customStyleBundle);

            BundleTable.EnableOptimizations = true;
        }
    }
}