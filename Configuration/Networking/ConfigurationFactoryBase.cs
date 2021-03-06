﻿
using System;
using UAOOI.Configuration.Networking.Serialization;
using UAOOI.Configuration.Networking.Serializers;

namespace UAOOI.Configuration.Networking
{
  /// <summary>
  /// Class ConfigurationFactory - provides basic implementation of the <see cref="IConfigurationFactory"/>.
  /// </summary>
  /// <remarks>In production release it shall be replaced by reading a configuration file.</remarks>
  public abstract class ConfigurationFactoryBase : IConfigurationFactory
  {
    #region IConfigurationFactory
    /// <summary>
    /// Gets the configuration.
    /// </summary>
    /// <returns>Am object of <see cref="ConfigurationData" /> type capturing the communication configuration.</returns>
    public ConfigurationData GetConfiguration()
    {
      return ConfigurationDataFactoryIO.Load(Loader, RaiseEvents);
    }
    /// <summary>
    /// Occurs after the association configuration has been changed.
    /// </summary>
    public abstract event EventHandler<EventArgs> OnAssociationConfigurationChange;
    /// <summary>
    /// Occurs after the communication configuration has been changed.
    /// </summary>
    public abstract event EventHandler<EventArgs> OnMessageHandlerConfigurationChange;
    #endregion

    /// <summary>
    /// Gets or sets the loader of the configuration.
    /// </summary>
    /// <remarks>Allows late binding - injection point of the configuration loader.</remarks>
    /// <value>The loader that is to be used to create or load new instance of <see cref="ConfigurationData"/>.</value>
    public Func<ConfigurationData> Loader { get; set; }
    protected abstract void RaiseEvents();

  }
}
