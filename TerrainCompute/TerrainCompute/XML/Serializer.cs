using System;
using System.ComponentModel;
using System.IO;
using System.Xml.Serialization;

namespace TerrainComputeC.XML
{
	//[LicenseProvider(typeof(Class46))]
	public class Serializer
	{
		public Serializer()
		{
			//System.ComponentModel.LicenseManager.Validate(typeof(Serializer));
			//base..ctor();
		}

		public static EntityList Deserialize(string fileName)
		{
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(EntityList));
			EntityList result = new EntityList();
			using (StreamReader streamReader = new StreamReader(fileName))
			{
				result = (EntityList)xmlSerializer.Deserialize(streamReader);
				streamReader.Close();
			}
			return result;
		}

		public static void Serialize(string fileName, EntityList entities)
		{
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(EntityList));
			using (StreamWriter streamWriter = new StreamWriter(fileName))
			{
				xmlSerializer.Serialize(streamWriter, entities);
				streamWriter.Flush();
			}
		}
	}
}
