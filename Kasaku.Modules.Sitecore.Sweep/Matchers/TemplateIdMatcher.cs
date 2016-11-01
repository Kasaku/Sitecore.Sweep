using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using Kasaku.Sitecore.Modules.Sweep.Utils;
using Sitecore.Configuration;
using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;

namespace Kasaku.Sitecore.Modules.Sweep.Matchers
{
    public class TemplateIdMatcher : IMatchStrategy
    {
        private static readonly XmlNode _templateMatcherNode;

        private static readonly ID[] _templateIDs;

        static TemplateIdMatcher()
        {
            _templateMatcherNode = Factory.GetConfigNode("/sitecore/sweep/templateIdMatcher", false);

            Assert.IsNotNull(_templateMatcherNode, "TemplateIdMatcher strategy requires sitecore/sweep/templateIdMatcher configuration to be defined.");

            var includedTemplates = _templateMatcherNode.SelectNodes("./template");

            if (includedTemplates != null && includedTemplates.Count > 0)
            {
                var fields = new HashSet<ID>();

                foreach (XmlElement template in includedTemplates)
                {
                    ID templateID;
                    if (ID.TryParse(template.InnerText, out templateID))
                    {
                        fields.Add(templateID);
                    }
                    else
                    {
                        throw new InvalidOperationException(string.Format("Template value \"{0}\" did not parse as a valid ID.", template.InnerText));
                    }
                }

                _templateIDs = fields.ToArray();
            }
            else
            {
                _templateIDs = new ID[] {};
            }
        }

        public bool IsMatch(Item contentItem, Field field)
        {
            return _templateIDs.Any(id => contentItem.TemplateID == id) && field.IsRichTextField();
        }
    }
}