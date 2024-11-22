namespace UpdateVersionInfo;

public class ParamAttributes
{
   /// <summary>
   /// [ParamAttributes.Help(true,"-?", "Shows help/usage information.")]
   /// </summary>
   [AttributeUsage(AttributeTargets.Property)]
   public class HelpAttribute : Attribute
   {
      public HelpAttribute(bool isVisisible, string param, string helpText)
      {
         IsVisisible = isVisisible;
         Param = param;
         HelpText = helpText;
      }

      public bool IsVisisible { get; }
      public string Param { get; }
      public string HelpText { get; }
   }
}

