﻿//#define Schema43
using Humanizer;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SAEON.Observations.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAEON.Observations.WebAPI
{
    public class MetadataAffiliation
    {
        public string Name { get; set; }
        public string Identifier { get; set; }
        public string Scheme { get; set; }
        public string SchemeUri { get; set; }

        public JObject AsJson()
        {
            var jObj = new JObject(new JProperty("affiliation", Name));
#if Schema43
            if (!string.IsNullOrWhiteSpace(Identifier))
            {
                new JProperty("affiliationIdentifier", Identifier);
            }
            if (!string.IsNullOrWhiteSpace(Scheme))
            {
                jObj.Add(new JProperty("affiliationIdentifierScheme", Scheme));
            }
            if (!string.IsNullOrWhiteSpace(SchemeUri))
            {
                jObj.Add(new JProperty("schemeURI", SchemeUri));
            }
#endif
            return jObj;
        }
    }

    public class MetadataAlternateIdentifier
    {
        public string Name { get; set; }
        public string Type { get; set; }

        public JObject AsJson()
        {
            var jObj = new JObject(new JProperty("alternateIdentifier", Name));
            if (!string.IsNullOrWhiteSpace(Type))
            {
                jObj.Add(new JProperty("alternateIdentifierType", Type));
            }
            return jObj;
        }
    }

    public class MetadataNameIdentifier
    {
        public string Name { get; set; }
        public string Scheme { get; set; }
        public string SchemeUri { get; set; }

        public JObject AsJson()
        {
            var jObj = new JObject(new JProperty("nameIdentifier", Name));
            if (!string.IsNullOrWhiteSpace(Scheme))
            {
                jObj.Add(new JProperty("nameIdentifierScheme", Scheme));
            }
            if (!string.IsNullOrWhiteSpace(SchemeUri))
            {
                jObj.Add(new JProperty("schemeURI", SchemeUri));
            }
            return jObj;
        }
    }

    public class MetadataCreator
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string FirstNames { get; set; }
        public string Surname { get; set; }
        public List<MetadataNameIdentifier> Identifiers { get; set; } = new List<MetadataNameIdentifier>();
        public List<MetadataAffiliation> Affiliations { get; set; } = new List<MetadataAffiliation>();

        public virtual JObject AsJson()
        {
            var jObj = new JObject(
                new JProperty("name", Name),
                new JProperty("nameType", Type)
                );
            if (Identifiers?.Any() ?? false)
            {
                jObj.Add(new JProperty("nameIdentifiers", new JArray(Identifiers.Select(i => i.AsJson()))));
            }
            if (Affiliations?.Any() ?? false)
            {
                jObj.Add(new JProperty("affiliations", new JArray(Affiliations.Select(i => i.AsJson()))));
            }
            return jObj;
        }
    }

    public class MetadataContributor : MetadataCreator
    {
        public string ContributorType { get; set; }

        public override JObject AsJson()
        {
            var jObj = base.AsJson();
            jObj.Add(new JProperty("contributorType", ContributorType));
            return jObj;
        }
    }

    public class MetadataRelatedIdentifier
    {
        public string Name { get; set; }
        public string Identifier { get; set; }
        public string Type { get; set; }

        public JObject AsJson()
        {
            var jObj = new JObject(
                new JProperty("relationType", Name),
                new JProperty("relatedIdentifier", Identifier),
                new JProperty("relatedIdentifierType", Type)
                );
            return jObj;
        }
    }

    public class MetadataResourceType
    {
        public string Name { get; set; }
        public string Type { get; set; }

        public JObject AsJson()
        {
            var jObj = new JObject(
                new JProperty("resourceTypeGeneral", Name),
                new JProperty("resourceType", Type));
            return jObj;
        }
    }

    public class MetadataRights
    {
        public string Name { get; set; }
        public string URI { get; set; }
        public string Identifier { get; set; }
        public string Scheme { get; set; }
        public string SchemeUri { get; set; }

        public JObject AsJson()
        {
            var jObj = new JObject(new JProperty("rights", Name));
            if (!string.IsNullOrWhiteSpace(URI))
            {
                jObj.Add(new JProperty("rightsURI", URI));
            }
            if (!string.IsNullOrWhiteSpace(Identifier))
            {
                jObj.Add(new JProperty("rightsIdentifier", Identifier));
            }
            if (!string.IsNullOrWhiteSpace(Scheme))
            {
                jObj.Add(new JProperty("rightsIdentifierScheme", Scheme));
            }
            if (!string.IsNullOrWhiteSpace(SchemeUri))
            {
                jObj.Add(new JProperty("schemeURI", SchemeUri));
            }
            return jObj;
        }
    }

    public class MetadataSubject
    {
        public string Name { get; set; }
        public string Scheme { get; set; }
        public string SchemeUri { get; set; }
        public string ValueUri { get; set; }

        public JObject AsJson()
        {
            var jObj = new JObject(new JProperty("subject", Name));
            if (!string.IsNullOrWhiteSpace(Scheme))
            {
                jObj.Add(new JProperty("subjectScheme", Scheme));
            }
            if (!string.IsNullOrWhiteSpace(SchemeUri))
            {
                jObj.Add(new JProperty("schemeURI", SchemeUri));
            }
            if (!string.IsNullOrWhiteSpace(ValueUri))
            {
                jObj.Add(new JProperty("valueURI", ValueUri));
            }
            return jObj;
        }
    }

    public class Metadata
    {
        public Metadata Parent { get; set; }
        public DigitalObjectIdentifier DOI { get; set; }
        public string Identifier { get; set; }
        public List<MetadataAlternateIdentifier> AlternateIdentifiers { get; } = new List<MetadataAlternateIdentifier>();
        public MetadataCreator Creator = new MetadataCreator
        {
            Name = "SAEON Observations Database",
            Type = "Organizational",
            Identifiers = new List<MetadataNameIdentifier> { new MetadataNameIdentifier {
                Name = "https://ror.org/041j42q70", Scheme = "ROR", SchemeUri = "https://ror.org" } }
        };
        public string Language { get; set; } = "en-za";
        public MetadataResourceType ResourceType { get; } = new MetadataResourceType { Name = "Dataset", Type = "Observations" };
        public string Publisher { get; set; } = "South African Environmental Observation Network (SAEON)";
        public int? PublicationYear => StartDate?.Year ?? EndDate?.Year;
        public string Title { get; set; }
        public string Description { get; set; }
        public string DescriptionHtml { get; set; }
        public string ItemDescription { get; set; }
        public string ItemUrl { get; set; }
        public List<MetadataRights> Rights { get; } = new List<MetadataRights> {
            new MetadataRights {
                Name = "Attribution-ShareAlike 4.0 International (CC BY-SA 4.0)",
                URI = "https://creativecommons.org/licenses/by-sa/4.0",
                Identifier = "CC-BY-SA-4.0",
                Scheme = "SPDX",
                SchemeUri = "https://spdx.org/licenses"
            }
        };
        public List<MetadataSubject> Subjects { get; } = new List<MetadataSubject> {
            new MetadataSubject { Name = "Observations"},
            new MetadataSubject { Name = "South African Environmental Observation Network (SAEON)"},
            new MetadataSubject
            {
                Name = "Observations Database",
                Scheme = "SOFTWARE_APP",
                SchemeUri = "https://observations.saeon.ac.za"
            },
            new MetadataSubject
            {
                Name = "https://observations.saeon.ac.za",
                Scheme = "SOFTWARE_URL",
                SchemeUri = "https://observations.saeon.ac.za"
            }
        };
        public List<MetadataContributor> Contributors { get; set; } = new List<MetadataContributor>() {
            new MetadataContributor
            {
                Name = "South African Environmental Observation Network (SAEON), uLwazi node",
                Type = "Organizational",
                ContributorType = "DataCurator",
                Affiliations = new List<MetadataAffiliation>
                {
                    new MetadataAffiliation
                    {
                        Name = "South African Environmental Observation Network (SAEON)",
                        Scheme = "ROR",
                        SchemeUri = "https://ror.org/041j42q70"
                    }
                }
            },
            new MetadataContributor
            {
                Name="Parker-Nance, Tim",
                Type="Personal",
                ContributorType = "ContactPerson",
                FirstNames = "Tim",
                Surname = "Parker-Nance",
                Identifiers = new List<MetadataNameIdentifier>
                {
                    new MetadataNameIdentifier
                    {
                        Name="https://orcid.org/0000-0001-7040-7736",
                        Scheme="ORCID",
                        SchemeUri="https://orcid.org"
                    }
                },
                Affiliations = new List<MetadataAffiliation>
                {
                    new MetadataAffiliation
                    {
                        Name = "South African Environmental Observation Network (SAEON)",
                        Scheme = "ROR",
                        SchemeUri = "https://ror.org/041j42q70"
                    }
                }
            }
        };
        private DateTimeOffset? startDate;
        public DateTimeOffset? StartDate
        {
            get { return startDate; }
            set
            {
                if (startDate != value)
                {
                    startDate = value;
                    if (value.HasValue && (Parent != null) && (!Parent.StartDate.HasValue || (Parent.StartDate > value)))
                    {
                        Parent.StartDate = value;
                    }
                }
            }
        }
        private DateTimeOffset? endDate;
        public DateTimeOffset? EndDate
        {
            get => endDate;
            set
            {
                if (endDate != value)
                {
                    endDate = value;
                    if (value.HasValue && (Parent != null) && (!Parent.EndDate.HasValue || (Parent.EndDate < value)))
                    {
                        Parent.EndDate = value;
                    }
                }
            }
        }

        private double? latitudeNorth;
        public double? LatitudeNorth
        {
            get => latitudeNorth;
            set
            {
                if (latitudeNorth != value)
                {
                    latitudeNorth = value;
                    if (value.HasValue && (Parent != null) && (!Parent.LatitudeNorth.HasValue || (Parent.LatitudeNorth > value)))
                    {
                        Parent.LatitudeNorth = value;
                    }
                }
            }
        }
        private double? latitudeSouth;
        public double? LatitudeSouth
        {
            get => latitudeSouth;
            set
            {
                if (latitudeSouth != value)
                {
                    latitudeSouth = value;
                    if (value.HasValue && (Parent != null) && (!Parent.LatitudeSouth.HasValue || (Parent.LatitudeSouth < value)))
                    {
                        Parent.LatitudeSouth = value;
                    }
                }
            }
        }
        private double? longitudeWest;
        public double? LongitudeWest
        {
            get => longitudeWest;
            set
            {
                if (longitudeWest != value)
                {
                    longitudeWest = value;
                    if (value.HasValue && (Parent != null) && (!Parent.LongitudeWest.HasValue || (Parent.LongitudeWest > value)))
                    {
                        Parent.LongitudeWest = value;
                    }
                }
            }
        }
        private double? longitudeEast;
        public double? LongitudeEast
        {
            get => longitudeEast;
            set
            {
                if (longitudeEast != value)
                {
                    longitudeEast = value;
                    if (value.HasValue && (Parent != null) && (!Parent.LongitudeEast.HasValue || (Parent.LongitudeEast < value)))
                    {
                        Parent.LongitudeEast = value;
                    }
                }
            }
        }
        private double? elevationMinimum;
        public double? ElevationMinimum
        {
            get => elevationMinimum;
            set
            {
                if (elevationMinimum != value)
                {
                    elevationMinimum = value;
                    if (value.HasValue && (Parent != null) && (!Parent.ElevationMinimum.HasValue || (Parent.ElevationMinimum > value)))
                    {
                        Parent.ElevationMinimum = value;
                    }
                }
            }
        }
        private double? elevationMaximum;
        public double? ElevationMaximum
        {
            get => elevationMaximum;
            set
            {
                if (elevationMaximum != value)
                {
                    elevationMaximum = value;
                    if (value.HasValue && (Parent != null) && (!Parent.ElevationMaximum.HasValue || (Parent.ElevationMaximum < value)))
                    {
                        Parent.ElevationMaximum = value;
                    }
                }
            }
        }
        //public double? Latitude => LatitudeNorth.HasValue && LatitudeSouth.HasValue ? (LatitudeNorth + LatitudeSouth) / 2 : null;
        //public double? Longitude => LongitudeWest.HasValue && LongitudeEast.HasValue ? (LongitudeWest + LongitudeEast) / 2 : null;
        // To Do
        public MetadataRelatedIdentifier IsPartOf;

        public List<MetadataRelatedIdentifier> RelatedIdentifiers { get; } = new List<MetadataRelatedIdentifier>();

        public void Generate(string title = "", string description = "")
        {
            if (DOI == null) throw new InvalidOperationException($"{nameof(DOI)} cannot be null");
            if (string.IsNullOrWhiteSpace(title))
            {
                title = $"Observations from the {DOI.DOIType.Humanize(LetterCasing.LowerCase)} {DOI.Name} in the SAEON Observations Database";
            }
            if (string.IsNullOrWhiteSpace(description))
            {
                description = $"The observations from the {DOI.DOIType.Humanize(LetterCasing.LowerCase)} {DOI.Name} in the SAEON Observations Database";
            }
            if (StartDate.HasValue && EndDate.HasValue)
            {
                if (StartDate.Value == EndDate.Value)
                {
                    title += $" on {StartDate.Value:yyyy-MM-dd}";
                    description += $" on {startDate.Value.ToJsonDate()}";
                }
                else
                {
                    title += $" from {startDate.Value:yyyy-MM-dd} to {endDate.Value:yyyy-MM-dd}";
                    description += $" from {startDate.Value.ToJsonDate()} to {endDate.Value.ToJsonDate()}";
                }
            }
            Title = title;
            if (LatitudeNorth.HasValue && LatitudeSouth.HasValue && LongitudeWest.HasValue && LongitudeEast.HasValue)
            {
                if ((LatitudeNorth == LatitudeSouth) && (LongitudeWest == LongitudeEast))
                {
                    description += $" at {LatitudeNorth:f5} (N+/S-), {LongitudeWest:f5} (E-/W+)";
                }
                else
                {
                    description += $" in area {LatitudeNorth:f5},{LongitudeWest:f5} (N,W) {LatitudeSouth:f5},{LongitudeEast:f5} (S,E) (N+/S-,E-/W+)";
                }
            }
            if (ElevationMinimum.HasValue && ElevationMaximum.HasValue)
            {
                if (ElevationMinimum == ElevationMaximum)
                {
                    description += $" at {ElevationMinimum:f2}m above mean sea level";
                }
                else
                {
                    description += $" between {ElevationMinimum:f2}m and {ElevationMaximum:f2}m above mean sea level";
                }
            }
            var sbText = new StringBuilder();
            var sbHtml = new StringBuilder();
            sbHtml.AppendHtmlH3(title);
            sbText.AppendLine(description);
            sbHtml.AppendHtmlP(description);
            if (!string.IsNullOrWhiteSpace(ItemDescription))
            {
                var itemDescription = ItemDescription;
                if (!string.IsNullOrWhiteSpace(ItemUrl))
                {
                    if (ItemUrl.StartsWith("http", StringComparison.InvariantCultureIgnoreCase))
                    {
                        itemDescription += $" <a href='{ItemUrl}'>{ItemUrl}</a>";
                    }
                    else
                    {
                        itemDescription += $" {ItemUrl}";
                    }
                }
                sbHtml.AppendHtmlP(itemDescription);
            }
            if (DOI.Parent != null)
            {
                sbText.AppendLine($"This collection is part of the {(DOI.Parent.DOIType == DOIType.ObservationsDb ? "" : DOI.Parent.DOIType.Humanize(LetterCasing.LowerCase))} {DOI.Parent.Name} {DOI.Parent.DOI}");
                sbHtml.AppendHtmlP($"This collection is part of the {(DOI.Parent.DOIType == DOIType.ObservationsDb ? "" : DOI.Parent.DOIType.Humanize(LetterCasing.LowerCase))} {DOI.Parent.Name} <a href='{DOI.Parent.DOIUrl}'>{DOI.Parent.DOI}</a>");
                RelatedIdentifiers.Add(new MetadataRelatedIdentifier { Name = "IsPartOf", Identifier = DOI.Parent.DOI, Type = "DOI" });
            }
            var children = DOI.Children.OrderBy(i => i.Name).ToList();
            if (children.Count > 0)
            {
                sbText.AppendLine($"This collection includes observations from the following {((DOI.DOIType + 1).Humanize(LetterCasing.LowerCase).ToQuantity(children.Count, ShowQuantityAs.None))}: " +
                    string.Join(", ", children.Select(i => i.Name)));
                sbHtml.AppendHtmlP($"This collection includes observations from the following {((DOI.DOIType + 1).Humanize(LetterCasing.LowerCase).ToQuantity(children.Count, ShowQuantityAs.None))}:");
                sbHtml.AppendHtmlUL(children.Select(i => $"{i.Name} <a href='{i.DOIUrl}'>{i.DOI}</a>"));
                foreach (var child in children)
                {
                    RelatedIdentifiers.Add(new MetadataRelatedIdentifier { Name = "HasPart", Identifier = child.DOI, Type = "DOI" });
                }
            }
            sbHtml.AppendHtmlP($"{"Publisher:".HtmlB()} {Publisher} {PublicationYear}");
            if (StartDate.HasValue || EndDate.HasValue)
            {
                var dates = "Dates: ".HtmlB();
                if (StartDate.HasValue)
                {
                    dates += $" Created: {StartDate:yyyy-MM-dd}";
                }
                if (StartDate.HasValue && EndDate.HasValue)
                {
                    dates += $" Collected: {StartDate.ToJsonDate()}/{EndDate.ToJsonDate()}";
                }
                else if (StartDate.HasValue)
                {
                    dates += $" Collected:  {StartDate.ToJsonDate()}";
                }
                sbHtml.AppendHtmlP(dates);
            }
            if (Rights.Any())
            {
                sbHtml.AppendHtmlP($"{"License:".HtmlB()} {Rights[0].Name}");
            }
            sbHtml.AppendHtmlP($"{"Keywords:".HtmlB()} {string.Join(", ", Subjects.Where(i => !i.Name.StartsWith("http")).Select(i => i.Name).OrderBy(i => i))}");
            if (!string.IsNullOrWhiteSpace(DOI.MetadataUrl))
            {
                sbHtml.AppendHtmlP($"{"Metadata URL:".HtmlB()} <a href='{DOI.MetadataUrl}'>{DOI.MetadataUrl}</a>".Trim());
            }
            if (!string.IsNullOrWhiteSpace(DOI.QueryUrl))
            {
                sbHtml.AppendHtmlP($"{"Query URL:".HtmlB()} <a href='{DOI.QueryUrl}'>{DOI.QueryUrl}</a>".Trim());
            }
            sbHtml.AppendHtmlP($"{"Citation".HtmlB()} {Creator.Name} ({PublicationYear}): {Title}. {Publisher}. (dataset). <a href='{DOI.DOIUrl}'>{DOI.DOIUrl}</a>");
            Description = sbText.ToString().Replace(Environment.NewLine, " "); //.Replace(Environment.NewLine,"<br>");
            DescriptionHtml = sbHtml.ToString();
        }

        public string ToJson()
        {
            var jDates = new JArray();
            if (StartDate.HasValue)
            {
                jDates.Add(
                    new JObject(
                        new JProperty("date", StartDate.Value.ToString("yyyy-MM-dd")),
                        new JProperty("dateType", "Created")));
                jDates.Add(
                    new JObject(
                        new JProperty("date", StartDate.Value.ToString("yyyy-MM-dd")),
                        new JProperty("dateType", "Submitted")));
                jDates.Add(
                    new JObject(
                        new JProperty("date", StartDate.Value.ToString("yyyy-MM-dd")),
                        new JProperty("dateType", "Accepted")));
            }
            if (StartDate.HasValue && EndDate.HasValue)
            {
                jDates.Add(
                    new JObject(
                        new JProperty("date", $"{StartDate.Value.ToJsonDate()}/{EndDate.Value.ToJsonDate()}"),
                        new JProperty("dateType", "Valid")));
            }
            else if (StartDate.HasValue)
            {
                jDates.Add(
                    new JObject(
                        new JProperty("date", $"{StartDate.Value.ToJsonDate()}"),
                        new JProperty("dateType", "Valid")));
            }
            var jGeoLocations = new JArray();
            if (LatitudeNorth.HasValue && LatitudeSouth.HasValue && LongitudeWest.HasValue && LongitudeEast.HasValue)
            {
                if ((LatitudeNorth == latitudeSouth) && (LongitudeWest == LongitudeEast))
                {
                    jGeoLocations.Add(
                        new JObject(
                            //new JProperty("geoLocationPlace", $"{splits[0]}, {splits[1]}"),
                            new JProperty("geoLocationPoint",
                                new JObject(
                                    new JProperty("pointLatitude", LatitudeNorth.ToString()),
                                    new JProperty("pointLongitude", LongitudeWest.ToString())
                                )
                            )
                        ));
                }
                else
                {
                    jGeoLocations.Add(
                        new JObject(
                            new JProperty("geoLocationBox",
                                new JObject(
                                    new JProperty("westBoundLongitude", LongitudeWest.ToString()),
                                    new JProperty("eastBoundLongitude", LongitudeEast.ToString()),
                                    new JProperty("northBoundLatitude", LatitudeNorth.ToString()),
                                    new JProperty("southBoundLatitude", LatitudeSouth.ToString())
                                )
                            )
                        )
                    );
                }
            }
            var jObj =
                new JObject(
                    new JProperty("identifier",
                        new JObject(
                            new JProperty("identifier", Identifier),
                            new JProperty("identifierType", "DOI")
                        )
                    ),
                    new JProperty("language", Language),
                    new JProperty("resourceType", ResourceType.AsJson()),
                    new JProperty("publisher", Publisher),
                    new JProperty("publicationYear", PublicationYear.ToString()),
                    new JProperty("creators", new JArray(Creator.AsJson())),
                    new JProperty("dates", jDates),
                    new JProperty("titles",
                        new JArray(
                            new JObject(
                                new JProperty("title", Title)
                            )
                        )
                    ),
                    new JProperty("descriptions",
                        new JArray(
                            new JObject(
                                new JProperty("descriptionType", "Abstract"),
                                new JProperty("description", Description)
                            )
                        )
                    ),
                    new JProperty("rightsList", new JArray(Rights.Select(i => i.AsJson()))),
                    new JProperty("contributors", new JArray(Contributors.Select(i => i.AsJson()))),
                    new JProperty("subjects", new JArray(Subjects.Select(i => i.AsJson()))),
                    new JProperty("geoLocations", jGeoLocations),
                    new JProperty("alternateIdentifiers", new JArray(AlternateIdentifiers.Select(i => i.AsJson()))),
                    new JProperty("relatedIdentifiers", new JArray(RelatedIdentifiers.Select(i => i.AsJson()))),
                    new JProperty("immutableResource", new JObject(
                        new JProperty("resourceURL", DOI.QueryUrl)))
               );
            return jObj.ToString(Formatting.Indented);
        }

        public string ToHtml()
        {
            return DescriptionHtml;
        }
    }
}
