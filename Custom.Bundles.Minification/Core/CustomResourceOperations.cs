using System;
using System.Linq;
using System.Text;
using System.Resources;
using System.Collections;
using System.Globalization;
using System.Collections.Generic;

using Custom.Bundles.Minification.MinifieAlgoritms;

namespace Custom.Bundles.Minification.Core
{
    /// <summary>
    /// Classe com operações sob os arquivos de Resources
    /// </summary>
    internal sealed class CustomResourceOperations
    {
        /// <summary>
        /// Coleção de Arquivos de Resources, cada Resource terá um conjunto de arquivos de estilo
        /// </summary>
        private readonly List<ResourceManager> _resourceManager;

        /// <summary>
        /// Interface para abstração do tipo de Função para minificar arquivos de estilo
        /// </summary>
        private static IMinifieAlgoritms _minifiedOperations;

        /// <summary>
        /// Construtor da classe, com a escolha para do tipo de minificação será executado
        /// </summary>
        /// <param name="fileToMinifie">Enumerado com a escolha do Tipo de Minificação, se será CSS ou JS</param>
        internal CustomResourceOperations(FileTypeToMinifie fileToMinifie)
        {
            this._resourceManager = new List<ResourceManager>();
            switch (fileToMinifie)
            {
                case FileTypeToMinifie.CSS:
                    _minifiedOperations = new MinifieAlgoritmsCss();
                    this._resourceManager.Add(new ResourceManager("Custom.Bundles.Minification.ContentStyle",  typeof(ContentStyle).Assembly));
                    break;
                case FileTypeToMinifie.JS:
                    _minifiedOperations = new MinifieAlgoritmsJs();
                    this._resourceManager.Add(new ResourceManager("Custom.Bundles.Minification.Jquery", typeof(Jquery).Assembly));
                    this._resourceManager.Add(new ResourceManager("Custom.Bundles.Minification.JqueryVal", typeof(JqueryVal).Assembly));
                    this._resourceManager.Add(new ResourceManager("Custom.Bundles.Minification.Modernizr", typeof(Modernizr).Assembly));
                    this._resourceManager.Add(new ResourceManager("Custom.Bundles.Minification.Bootstrap", typeof(Bootstrap).Assembly));
                    break;
            }
        }

        /// <summary>
        /// Função pra iterar sob os Resources e seus respectivos arquivos a serem minificados
        /// </summary>
        /// <param name="FileContentSB">StringBuilder esperado para mudança de estados, concatenação com os conteúdos minificados</param>
        internal void IterateOnResourceRepository(ref StringBuilder fileContentSB)
        {
            ResourceSet resourceSet = null;
            global::System.Resources.ResourceManager[] ResourceManagerArray = new global::System.Resources.ResourceManager[] { };
            try
            {
                ResourceManagerArray = this._resourceManager.ToArray();
                DictionaryEntry[] filesAndContents = null;
                for (int i = 0; i < ResourceManagerArray.Length; i++)
                {
                    filesAndContents = new DictionaryEntry[] { };
                    resourceSet = ResourceManagerArray[i].GetResourceSet(CultureInfo.CurrentUICulture, true, true);
                    filesAndContents = resourceSet.OfType<DictionaryEntry>().OrderBy(x => x.Key).ToArray();
                    for (int j = 0; j < filesAndContents.Length; j++)
                    {
                        _minifiedOperations.ConcatenateAndMinifieContent(ref fileContentSB, filesAndContents[j].Value.ToString(), true);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Falha durante acesso ao arquivo de Resources.", ex);
            }
            finally
            {
                if (null != resourceSet)
                {
                    resourceSet.Dispose();
                }
            }
        }
    }
}