﻿using System;
using System.Xml.Linq;

namespace Cogito.Web.Configuration
{

    /// <summary>
    /// Provides configuration methods for 'system.webServer'.
    /// </summary>
    public class WebSystemWebServerConfigurator : IWebSectionConfigurator
    {

        readonly XElement element;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="element"></param>
        public WebSystemWebServerConfigurator(XElement element)
        {
            this.element = element ?? throw new ArgumentNullException(nameof(element));
        }

        /// <summary>
        /// Returns the configuration.
        /// </summary>
        /// <returns></returns>
        public XElement Element => element;

        /// <summary>
        /// Configures the 'asp' element.
        /// </summary>
        /// <param name="configurator"></param>
        /// <returns></returns>
        public WebSystemWebServerConfigurator Asp(Action<WebSystemWebServerAspConfigurator> configure)
        {
            this.Configure("asp", e => configure?.Invoke(new WebSystemWebServerAspConfigurator(e)));
            return this;
        }

        /// <summary>
        /// Configures the 'httpCompression' element.
        /// </summary>
        /// <param name="configurator"></param>
        /// <returns></returns>
        public WebSystemWebServerConfigurator HttpCompression(Action<WebSystemWebServerHttpCompressionConfigurator> configure)
        {
            this.Configure("httpCompression", e => configure?.Invoke(new WebSystemWebServerHttpCompressionConfigurator(e)));
            return this;
        }

    }

}
