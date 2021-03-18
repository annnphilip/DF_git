using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace Discussion_forum.Localization
{
    public static class Discussion_forumLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(Discussion_forumConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(Discussion_forumLocalizationConfigurer).GetAssembly(),
                        "Discussion_forum.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
