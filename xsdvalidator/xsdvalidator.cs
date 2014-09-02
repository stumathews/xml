using System.Xml;
using System.Xml.Schema;

public class XSDValidator
{

	private static bool isValid = true;
	public static void Main(string[] args)
	{

		if( args.Length == 0 || args.Length != 1)
		{
		
			System.Console.WriteLine("Usage: XSDValidator.exe <xml file>\nEnsure that the xsd is in the same folder as xml file.");
			return;
		}

		string xmlFileName = args[0];

		XmlTextReader r = new XmlTextReader(xmlFileName);
		XmlValidatingReader v = new XmlValidatingReader(r);

		v.ValidationType = ValidationType.Schema;
		v.ValidationEventHandler += new ValidationEventHandler( MyValidationEventHandler);

		while(v.Read())
		{

		}
		v.Close();

		if(!isValid)
			System.Console.WriteLine("Xml document is not valid.");
		else
			System.Console.WriteLine("Xml Document is valid.");
	}

	public static void MyValidationEventHandler( object sender, ValidationEventArgs args )
	{
		isValid = false;
		System.Console.WriteLine(args.Message);
	}
			
}
