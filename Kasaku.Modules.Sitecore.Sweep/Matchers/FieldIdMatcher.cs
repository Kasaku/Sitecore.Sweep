using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using Sitecore.Configuration;
using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;

namespace Kasaku.Sitecore.Modules.Sweep.Matchers
{
    public class FieldIdMatcher : IMatchStrategy
    {
        private static readonly XmlNode _fieldMatcherNode;

        private static readonly ID[] _fieldIds;

        static FieldIdMatcher()
        {
            _fieldMatcherNode = Factory.GetConfigNode("/sitecore/sweep/fieldIdMatcher", false);

            Assert.IsNotNull(_fieldMatcherNode, "FieldIdMatcher strategy requires sitecore/sweep/fieldIdMatcher configuration to be defined.");

            var includedFields = _fieldMatcherNode.SelectNodes("./field");

            if (includedFields != null && includedFields.Count > 0)
            {
                var fields = new HashSet<ID>();

                foreach (XmlElement field in includedFields)
                {
                    ID fieldID;
                    if (ID.TryParse(field.InnerText, out fieldID))
                    {
                        fields.Add(fieldID);
                    }
                    else
                    {
                        throw new InvalidOperationException(string.Format("Field value \"{0}\" did not parse as a valid ID.", field.InnerText));
                    }
                }

                _fieldIds = fields.ToArray();
            }
            else
            {
                _fieldIds = new ID[] {};
            }
        }

        public bool IsMatch(Item contentItem, Field field)
        {
            return _fieldIds.Any(id => field.ID == id);
        }
    }
}