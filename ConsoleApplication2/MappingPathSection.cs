using System;
using System.Configuration;

namespace ConsoleApplication2
{
    public class MappingPathSection : ConfigurationSection
    {
        [ConfigurationProperty("", IsDefaultCollection = true)]
        public BatchCollection Batchs
        {
            get
            {
                BatchCollection batchCollection = (BatchCollection)base[""];
                return batchCollection;
            }
        }
    }

    public class BatchCollection : ConfigurationElementCollection
    {
        public override ConfigurationElementCollectionType CollectionType
        {
            get { return ConfigurationElementCollectionType.BasicMap; }
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new BatchConfigElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((BatchConfigElement)element).BatchId;
        }

        protected override string ElementName
        {
            get { return "batch"; }
        }
    }
    public class BatchConfigElement : ConfigurationElement
    {
        [ConfigurationProperty("batchId", IsRequired = true, IsKey = true)]
        public string BatchId
        {
            get { return (string)this["batchId"]; }
            set { this["batchId"] = value; }
        }

        [ConfigurationProperty("source", IsRequired = false)]
        public string Source
        {
            get { return (string)this["source"]; }
            set { this["source"] = value; }
        }

        [ConfigurationProperty("mappings", IsDefaultCollection = false)]
        public MappingCollection Mappings
        {
            get { return (MappingCollection)base["mappings"]; }
        }
    }
    public class MappingCollection : ConfigurationElementCollection
    {

        public override ConfigurationElementCollectionType CollectionType
        {
            get { return ConfigurationElementCollectionType.BasicMap; }
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new MappingConfigElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((MappingConfigElement)element).Name;
        }
        protected override string ElementName
        {
            get { return "mapping"; }
        }
    }
    public class MappingConfigElement: ConfigurationElement
    {
        [ConfigurationProperty("name", IsRequired = true, IsKey = true, DefaultValue = "")]
        public string Name
        {
            get { return (string)this["name"]; }
            set { this["name"] = value; }
        }

        [ConfigurationProperty("sourcePath", IsRequired = true, DefaultValue = "")]
        public string SourcePath
        {
            get { return (string)this["sourcePath"]; }
            set { this["sourcePath"] = value; }
        }

        [ConfigurationProperty("koolKeeperPath", IsRequired = true, DefaultValue = "")]
        public string KoolkeeperPath
        {
            get { return (string)this["koolKeeperPath"]; }
            set { this["koolKeeperPath"] = value; }
        }

        [ConfigurationProperty("active", IsRequired = true, DefaultValue = false)]
        public bool Active
        {
            get { return (bool)this["active"]; }
            set { this["active"] = value; }
        }
    }
}
