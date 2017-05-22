Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.IO
Imports DocumentFormat.OpenXml
Imports DocumentFormat.OpenXml.Packaging
Imports DocumentFormat.OpenXml.Spreadsheet
Imports DocumentFormat.OpenXml.Drawing.Spreadsheet
Imports X14 = DocumentFormat.OpenXml.Office2010.Excel
Imports System.Collections
Imports System.Data
Imports System.Reflection
Imports System.Configuration
Imports System.Runtime.CompilerServices

Namespace Helpers
    Public Module ExportaExcelXLSX

        Private Function CreateStylesheet() As Stylesheet

            Dim stylesheet1 As New Stylesheet() With {.MCAttributes = New MarkupCompatibilityAttributes() With {.Ignorable = "x14ac"}}

            stylesheet1.AddNamespaceDeclaration("mc", "http://schemas.openxmlformats.org/markup-compatibility/2006")
            stylesheet1.AddNamespaceDeclaration("x14ac", "http://schemas.microsoft.com/office/spreadsheetml/2009/9/ac")

            Dim fonts1 As New Fonts() With {.Count = Convert.ToUInt32(2)}

            Dim font1 As New Font()

            Dim fontSize1 As New FontSize() With {.Val = 11.0}

            Dim fontName1 As New FontName() With {.Val = "Calibri"}

            font1.Append(fontSize1)
            font1.Append(fontName1)

            Dim font2 As New Font()
            Dim fontSize2 As New FontSize() With { _
                .Val = 11.0 _
            }
            Dim color1 As New Color() With { _
                .Theme = Convert.ToUInt32(0) _
            }
            Dim fontName2 As New FontName() With { _
                .Val = "Calibri" _
            }
            Dim fontFamilyNumbering1 As New FontFamilyNumbering() With { _
                .Val = 2 _
            }

            font2.Append(fontSize2)
            font2.Append(color1)
            font2.Append(fontName2)
            font2.Append(fontFamilyNumbering1)

            fonts1.Append(font1)
            fonts1.Append(font2)

            Dim fills1 As New Fills() With { _
                .Count = 3 _
            }

            Dim fill1 As New Fill()
            Dim patternFill1 As New PatternFill() With { _
                .PatternType = PatternValues.None _
            }

            fill1.Append(patternFill1)

            Dim fill2 As New Fill()
            Dim patternFill2 As New PatternFill() With { _
                .PatternType = PatternValues.Gray125 _
            }

            fill2.Append(patternFill2)

            Dim fill3 As New Fill()

            Dim patternFill3 As New PatternFill() With { _
                .PatternType = PatternValues.Solid _
            }
            Dim foregroundColor1 As New ForegroundColor() With { _
                .Theme = 3, _
                .Tint = -0.249977111117893 _
            }
            Dim backgroundColor1 As New BackgroundColor() With { _
                .Indexed = 64 _
            }

            patternFill3.Append(foregroundColor1)
            patternFill3.Append(backgroundColor1)

            fill3.Append(patternFill3)

            fills1.Append(fill1)
            fills1.Append(fill2)
            fills1.Append(fill3)

            Dim borders1 As New Borders() With { _
                .Count = 1 _
            }

            Dim border1 As New Border()
            Dim leftBorder1 As New LeftBorder()
            Dim rightBorder1 As New RightBorder()
            Dim topBorder1 As New TopBorder()
            Dim bottomBorder1 As New BottomBorder()
            Dim diagonalBorder1 As New DiagonalBorder()

            border1.Append(leftBorder1)
            border1.Append(rightBorder1)
            border1.Append(topBorder1)
            border1.Append(bottomBorder1)
            border1.Append(diagonalBorder1)

            borders1.Append(border1)

            Dim cellStyleFormats1 As New CellStyleFormats() With { _
                .Count = 1 _
            }
            Dim cellFormat1 As New CellFormat() With { _
                .NumberFormatId = 0, _
                .FontId = 0, _
                .FillId = 0, _
                .BorderId = 0 _
            }

            cellStyleFormats1.Append(cellFormat1)

            Dim cellFormats1 As New CellFormats() With { _
                .Count = 2 _
            }
            Dim cellFormat2 As New CellFormat() With { _
                .NumberFormatId = 0, _
                .FontId = 0, _
                .FillId = 0, _
                .BorderId = 0, _
                .FormatId = 0 _
            }

            Dim cellFormat3 As New CellFormat() With { _
                .NumberFormatId = 0, _
                .FontId = 1, _
                .FillId = 2, _
                .BorderId = 0, _
                .FormatId = 0, _
                .ApplyFont = True, _
                .ApplyFill = True, _
                .ApplyAlignment = True _
            }
            Dim alignment1 As New Alignment() With { _
                .Horizontal = HorizontalAlignmentValues.Center _
            }

            cellFormat3.Append(alignment1)

            cellFormats1.Append(cellFormat2)
            cellFormats1.Append(cellFormat3)

            Dim cellStyles1 As New CellStyles() With { _
                .Count = 1 _
            }
            Dim cellStyle1 As New CellStyle() With { _
                .Name = "Normal", _
                .FormatId = 0, _
                .BuiltinId = 0 _
            }

            cellStyles1.Append(cellStyle1)
            Dim differentialFormats1 As New DifferentialFormats() With { _
                .Count = 0 _
            }

            Dim tableStyles1 As New TableStyles() With { _
                .Count = Convert.ToUInt32(0), _
                .DefaultTableStyle = "TableStyleMedium9", _
                .DefaultPivotStyle = "PivotStyleLight16" _
            }

            Dim stylesheetExtensionList1 As New StylesheetExtensionList()

            Dim stylesheetExtension1 As New StylesheetExtension() With {.Uri = "{EB79DEF2-80B8-43e5-95BD-54CBDDF9020C}"}
            stylesheetExtension1.AddNamespaceDeclaration("x14", "http://schemas.microsoft.com/office/spreadsheetml/2009/9/main")

            Dim slicerStyles1 As New X14.SlicerStyles() With {.DefaultSlicerStyle = "SlicerStyleLight1"}

            stylesheetExtension1.Append(slicerStyles1)

            stylesheetExtensionList1.Append(stylesheetExtension1)

            stylesheet1.Append(fonts1)
            stylesheet1.Append(fills1)
            stylesheet1.Append(borders1)
            stylesheet1.Append(cellStyleFormats1)
            stylesheet1.Append(cellFormats1)
            stylesheet1.Append(cellStyles1)
            stylesheet1.Append(differentialFormats1)
            stylesheet1.Append(tableStyles1)
            stylesheet1.Append(stylesheetExtensionList1)
            Return stylesheet1
        End Function

        <Extension()>
        Public Function ExportaExcel(Of T)(_DataSource As List(Of T), ByVal _NombreHoja As String) As String
            Try
                Dim _nombreArchivo = "~/FilesDownloaded/" + DateTime.Now.ToShortDateString().Replace("/", "") + "_" + DateTime.Now.Hour.ToString() + "_" + DateTime.Now.Minute.ToString() + "_" + DateTime.Now.Second.ToString() + ".xlsx"
                _nombreArchivo = HttpContext.Current.Server.MapPath(_nombreArchivo)


                Using ssd As SpreadsheetDocument = SpreadsheetDocument.Create(_nombreArchivo, SpreadsheetDocumentType.Workbook, True)
                    Dim Wbp As WorkbookPart = ssd.AddWorkbookPart()
                    Dim wb As New Workbook()
                    Dim shets As New Sheets()

                    Dim shet As New Sheet() With {.Name = _NombreHoja, _
                        .SheetId = 1, _
                        .Id = "rId1"}

                    shets.Append(shet)
                    wb.Append(shets)
                    Wbp.Workbook = wb
                    Dim wsp = Wbp.AddNewPart(Of WorksheetPart)("rId1")
                    Dim ws As New Worksheet()
                    Dim sd As New SheetData()

                    Dim wbsp As WorkbookStylesPart = Wbp.AddNewPart(Of WorkbookStylesPart)()
                    wbsp.Stylesheet = CreateStylesheet()
                    wbsp.Stylesheet.Save()

                    Dim cont As Integer = 0

                    'if (_DataSource.Count.Equals(0))
                    '{
                    '    throw new Exception("No hay datos para exportar"); 
                    '}

                    For Each v In _DataSource
                        If cont = 0 Then
                            ' las de la primer fila son las columnas 
                            Dim propiedades = v.[GetType]().GetProperties()
                            Dim i As Integer = 0
                            Dim _row = New Row() With {.RowIndex = 1
                            }
                            For Each p In propiedades
                                Dim _cell = New Cell() With {.CellReference = RegresaColumna(i) & Convert.ToString("1"), _
                                     .CellValue = New CellValue(p.Name.ToUpper()), _
                                     .DataType = CellValues.[String],
                                                             .StyleIndex = 1
                                }
                                _row.Append(_cell)
                                i += 1
                            Next
                            sd.Append(_row)
                        End If

                        Dim _propiedades = v.[GetType]().GetProperties()
                        Dim fila = New Row() With {
                            .RowIndex = (Convert.ToUInt32(cont) + 2)
                        }

                        Dim j As Integer = 0
                        For Each q In _propiedades
                            Dim valor As String = If(v.[GetType]().GetProperty(q.Name).GetValue(v, Nothing) Is Nothing, "", v.[GetType]().GetProperty(q.Name).GetValue(v, Nothing).ToString())

                            Dim cvalues As CellValues = CellValues.[String]

                            Dim tipo As Type = q.PropertyType
                            If tipo = GetType(DateTime) OrElse tipo = GetType(Nullable(Of DateTime)) Then
                                If valor.Length > 10 Then
                                    valor = valor.Substring(0, 10)
                                    'valor = Convert.ToDateTime(valor).ToOADate().ToString()
                                    'cvalues = CellValues.Number
                                End If
                            End If

                            If tipo = GetType(Integer) OrElse tipo = GetType(Long) OrElse tipo = GetType(Decimal) OrElse tipo = GetType(Single) OrElse tipo = GetType(Nullable(Of Integer)) OrElse tipo = GetType(Nullable(Of Decimal)) Then
                                cvalues = CellValues.Number
                            End If

                            Dim columna = New Cell() With {
                                .CellReference = RegresaColumna(j) + ((cont + 2).ToString()), _
                                .StyleIndex = 0UI, _
                                .CellValue = New CellValue(valor), _
                                .DataType = cvalues _
                            }

                            fila.Append(columna)
                            j += 1
                        Next

                        sd.Append(fila)
                        cont += 1
                    Next
                    ws.Append(sd)
                    wsp.Worksheet = ws
                    ws.Save()
                End Using

                Return _nombreArchivo
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Friend Function RegresaColumna(entero As Integer) As String
            Dim letras As String() = {"A", "B", "C", "D", "E", "F", _
                "G", "H", "I", "J", "k", "L", _
                "M", "N", "O", "P", "Q", "R", _
                "S", "T", "U", "V", "W", "X", _
                "Y", "Z"}
            If entero < 26 Then
                Return letras(entero)
            Else
                Dim aux As Integer = (entero / 26) - 1
                Dim res As Integer = entero Mod 26
                Return letras(aux) + letras(res)
            End If
        End Function
    End Module
End Namespace
