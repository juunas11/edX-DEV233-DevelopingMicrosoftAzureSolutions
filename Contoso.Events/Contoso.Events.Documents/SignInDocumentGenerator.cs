using Contoso.Events.Models;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Contoso.Events.Documents
{
    public class SignInDocumentGenerator
    {
        public MemoryStream CreateSignInDocument(string eventTitle, params string[] names)
        {
            return CreateSignInDocument(eventTitle, names);
        }

        public MemoryStream CreateSignInDocument(Event eventItem)
        {
            MemoryStream stream = new MemoryStream();
            string eventTitle = eventItem.Title;
            List<Registration> registrants = eventItem.Registrants
                .OrderByDescending(er => er.Timestamp)
                .ToList();
            CreateDocument(stream, eventTitle, registrants);
            return stream;
        }

        private static void CreateDocument(Stream stream, string eventName, IEnumerable<Registration> registrants)
        {
            using (WordprocessingDocument doc = WordprocessingDocument.Create(stream, WordprocessingDocumentType.Document, true))
            {
                MainDocumentPart mainDocumentPart = doc.AddMainDocumentPart();

                mainDocumentPart.Document = new Document(
                    new Body()
                );

                mainDocumentPart.Document.Body.Append(
                    CreateHeaderParagraph(eventName)
                );

                Table table = CreateTable(registrants);

                mainDocumentPart.Document.Body.Append(table);

                mainDocumentPart.Document.Save();
            }
        }

        private static Table CreateTable(IEnumerable<Registration> registrants)
        {
            Table table = new Table(
                new TableProperties(
                    new TableWidth()
                    {
                        Width = "5000",
                        Type = TableWidthUnitValues.Pct
                    }
                )
            );

            foreach (var registrant in registrants)
            {
                table.Append(
                    CreateTableRow(registrant)
                );
            }
            return table;
        }

        private static TableRow CreateTableRow(Registration registrant)
        {
            return new TableRow(
                new TableCell(
                    new TableCellProperties(
                        new TableCellVerticalAlignment() { Val = TableVerticalAlignmentValues.Bottom },
                        new TableCellWidth() { Type = TableWidthUnitValues.Pct, Width = "1000" }
                    ),
                    new Paragraph(
                        new ParagraphProperties(
                            new SpacingBetweenLines() { After = "0" }
                        ),
                        new Run(
                            new RunProperties(
                                new FontSize()
                                {
                                    Val = new StringValue("16")
                                }
                            ),
                            new Text(String.Format("{1}, {0}", registrant.FirstName, registrant.LastName))
                        )
                    )
                ),
                new TableCell(
                    new TableCellProperties(
                        new TableCellVerticalAlignment() { Val = TableVerticalAlignmentValues.Bottom },
                        new TableCellWidth() { Type = TableWidthUnitValues.Pct, Width = "1000" }
                    ),
                    new Paragraph(
                        new ParagraphProperties(
                            new SpacingBetweenLines() { After = "0" }
                        ),
                        new Run(
                            new RunProperties(
                                new FontSize()
                                {
                                    Val = new StringValue("16")
                                }
                            ),
                            new Text(registrant.EmailAddress)
                        )
                    )
                ),
                new TableCell(
                    new TableCellProperties(
                        new TableCellWidth() { Type = TableWidthUnitValues.Pct, Width = "3000" },
                        new TableCellBorders() { BottomBorder = new BottomBorder { Val = BorderValues.Single, Size = 2 } }
                    ),
                    new Paragraph(
                        new Run()
                    )
                )
            );
        }

        private static Paragraph CreateHeaderParagraph(string eventName)
        {
            return new Paragraph(
                new ParagraphProperties(
                    new Justification()
                    {
                        Val = JustificationValues.Center
                    }
                ),
                new Run(
                    new RunProperties(
                        new RunFonts()
                        {
                            Ascii = "Calibri Light"
                        },
                        new FontSize()
                        {
                            Val = new StringValue("48")
                        }
                    ),
                    new Text(eventName),
                    new CarriageReturn()
                )
            );
        }
    }
}