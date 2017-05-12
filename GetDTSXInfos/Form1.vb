Imports System.Text.RegularExpressions
Imports System.IO
Imports System.Xml

Public Class Form1

    Private m_strFolder As String = String.Empty
    Private m_lst As New List(Of PackageInfo)

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Using fbd As New FolderBrowserDialog

            fbd.ShowDialog()

            m_strFolder = fbd.SelectedPath

            TextBox1.Text = m_strFolder

        End Using

    End Sub

    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click

        If Not String.IsNullOrEmpty(m_strFolder) Then

            If rdRegEx.Checked Then
                ReadPackagesInfo(m_strFolder)
            Else
                ReadPackagesInfoUsingXmlParser(m_strFolder)
            End If


            DataGridView1.DataSource = m_lst
            DataGridView1.Refresh()
        Else
            MsgBox("You have to select a Source Folder")

        End If


    End Sub

    Private Sub ReadPackagesInfo(ByVal strDirectory As String)


        m_lst.Clear()

        For Each strFile As String In IO.Directory.GetFiles(strDirectory, "*.dtsx", IO.SearchOption.AllDirectories)


            Dim strContent As String = ""

            Using sr As New IO.StreamReader(strFile)

                strContent = sr.ReadToEnd
                sr.Close()

            End Using


            Dim strPackageFormatVersion As String = Regex.Match(strContent, "(?<=""PackageFormatVersion"">)(.*)(?=</DTS:Property>)", RegexOptions.Singleline).Value
            Dim strCreationDate As String = Regex.Match(strContent, "(?<=DTS:CreationDate="")(.*?)(?="")", RegexOptions.Singleline).Value
            Dim strCreationName As String = Regex.Match(strContent, "(?<=DTS:CreationName="")(.*?)(?="")", RegexOptions.Singleline).Value
            Dim strCreatorComputerName As String = Regex.Match(strContent, "(?<=DTS:CreatorComputerName="")(.*?)(?="")", RegexOptions.Singleline).Value
            Dim strCreatorName As String = Regex.Match(strContent, "(?<=DTS:CreatorName="")(.*?)(?="")", RegexOptions.Singleline).Value
            Dim strDTSID As String = Regex.Match(strContent, "(?<=DTS:DTSID="")(.*?)(?="")", RegexOptions.Singleline).Value
            Dim strExecutableType As String = Regex.Match(strContent, "(?<=DTS:ExecutableType="")(.*?)(?="")", RegexOptions.Singleline).Value
            Dim strLastModifiedProductVersion As String = Regex.Match(strContent, "(?<=DTS:LastModifiedProductVersion="")(.*?)(?="")", RegexOptions.Singleline).Value
            Dim strLocaleID As String = Regex.Match(strContent, "(?<=DTS:LocaleID="")(.*?)(?="")", RegexOptions.Singleline).Value
            Dim strObjectName As String = Regex.Match(strContent, "(?<=DTS:ObjectName="")(.*?)(?="")", RegexOptions.Singleline).Value
            Dim strPackageType As String = Regex.Match(strContent, "(?<=DTS:PackageType="")(.*?)(?="")", RegexOptions.Singleline).Value
            Dim strVersionBuild As String = Regex.Match(strContent, "(?<=DTS:VersionBuild="")(.*?)(?="")", RegexOptions.Singleline).Value
            Dim strVersionGUID As String = Regex.Match(strContent, "(?<=DTS:VersionGUID="")(.*?)(?="")", RegexOptions.Singleline).Value



            m_lst.Add(New PackageInfo With {.PackageFileName = strFile,
                          .PackageFormatVersion = strPackageFormatVersion,
                          .CreationDate = strCreationDate,
                          .CreationName = strCreationName,
                          .CreatorComputerName = strCreatorComputerName,
                          .CreatorName = strCreatorName,
                          .DTSID = strDTSID,
                          .ExecutableType = strExecutableType,
                          .LastModifiedProductVersion = strLastModifiedProductVersion,
                          .LocaleID = strLocaleID,
                          .ObjectName = strObjectName,
                          .PackageType = strPackageType,
                          .VersionBuild = strVersionBuild,
                         .VersionGUID = strVersionGUID})


        Next



    End Sub

    Private Sub ReadPackagesInfoUsingXmlParser(ByVal strDirectory As String)

        m_lst.Clear()

        For Each strFile As String In IO.Directory.GetFiles(strDirectory, "*.dtsx", IO.SearchOption.AllDirectories)

            Dim strPackageFormatVersion As String = ""
            Dim strCreationDate As String = ""
            Dim strCreationName As String = ""
            Dim strCreatorComputerName As String = ""
            Dim strCreatorName As String = ""
            Dim strDTSID As String = ""
            Dim strExecutableType As String = ""
            Dim strLastModifiedProductVersion As String = ""
            Dim strLocaleID As String = ""
            Dim strObjectName As String = ""
            Dim strPackageType As String = ""
            Dim strVersionBuild As String = ""
            Dim strVersionGUID As String = ""


            Dim xml = XDocument.Load(strFile)

            Dim ns As XNamespace = "www.microsoft.com/SqlServer/Dts"
            Dim man As XmlNamespaceManager = New XmlNamespaceManager(New NameTable())
            man.AddNamespace("DTS", "www.microsoft.com/SqlServer/Dts")

            If Not xml.Root Is Nothing AndAlso
                    Not xml.Root.Descendants(ns + "Property").Attributes(ns + "Name") Is Nothing AndAlso
                         xml.Root.Descendants(ns + "Property").Attributes(ns + "Name").Where(Function(x) x.Value = "PackageFormatVersion").Count > 0 Then

                strPackageFormatVersion = xml.Root.Descendants(ns + "Property").Attributes(ns + "Name").Where(Function(x) x.Value = "PackageFormatVersion").FirstOrDefault.Parent.Value

                strCreationDate = If(xml.Root.Attributes(ns + "CreationDate").FirstOrDefault Is Nothing, "", xml.Root.Attributes(ns + "CreationDate").FirstOrDefault.Value)
                strCreationName = If(xml.Root.Attributes(ns + "CreationName").FirstOrDefault Is Nothing, "", xml.Root.Attributes(ns + "CreationName").FirstOrDefault.Value)
                strCreatorComputerName = If(xml.Root.Attributes(ns + "CreatorComputerName").FirstOrDefault Is Nothing, "", xml.Root.Attributes(ns + "CreatorComputerName").FirstOrDefault.Value)
                strCreatorName = If(xml.Root.Attributes(ns + "CreatorName").FirstOrDefault Is Nothing, "", xml.Root.Attributes(ns + "CreatorName").FirstOrDefault.Value)
                strDTSID = If(xml.Root.Attributes(ns + "DTSID").FirstOrDefault Is Nothing, "", xml.Root.Attributes(ns + "DTSID").FirstOrDefault.Value)
                strExecutableType = If(xml.Root.Attributes(ns + "ExecutableType").FirstOrDefault Is Nothing, "", xml.Root.Attributes(ns + "ExecutableType").FirstOrDefault.Value)
                strLastModifiedProductVersion = If(xml.Root.Attributes(ns + "LastModifiedProductVersion").FirstOrDefault Is Nothing, "", xml.Root.Attributes(ns + "LastModifiedProductVersion").FirstOrDefault.Value)
                strLocaleID = If(xml.Root.Attributes(ns + "LocaleID").FirstOrDefault Is Nothing, "", xml.Root.Attributes(ns + "LocaleID").FirstOrDefault.Value)
                strObjectName = If(xml.Root.Attributes(ns + "ObjectName").FirstOrDefault Is Nothing, "", xml.Root.Attributes(ns + "ObjectName").FirstOrDefault.Value)
                strPackageType = If(xml.Root.Attributes(ns + "PackageType").FirstOrDefault Is Nothing, "", xml.Root.Attributes(ns + "PackageType").FirstOrDefault.Value)
                strVersionBuild = If(xml.Root.Attributes(ns + "VersionBuild").FirstOrDefault Is Nothing, "", xml.Root.Attributes(ns + "VersionBuild").FirstOrDefault.Value)
                strVersionGUID = If(xml.Root.Attributes(ns + "VersionGUID").FirstOrDefault Is Nothing, "", xml.Root.Attributes(ns + "VersionGUID").FirstOrDefault.Value)
            End If



            m_lst.Add(New PackageInfo With {.PackageFileName = strFile,
                          .PackageFormatVersion = strPackageFormatVersion,
                          .CreationDate = strCreationDate,
                          .CreationName = strCreationName,
                          .CreatorComputerName = strCreatorComputerName,
                          .CreatorName = strCreatorName,
                          .DTSID = strDTSID,
                          .ExecutableType = strExecutableType,
                          .LastModifiedProductVersion = strLastModifiedProductVersion,
                          .LocaleID = strLocaleID,
                          .ObjectName = strObjectName,
                          .PackageType = strPackageType,
                          .VersionBuild = strVersionBuild,
                         .VersionGUID = strVersionGUID})

        Next

    End Sub





End Class

Public Class PackageInfo

    Public Property PackageFileName As String
    Public Property PackageFormatVersion As String
    Public Property CreationDate As String
    Public Property CreationName As String
    Public Property CreatorComputerName As String
    Public Property CreatorName As String
    Public Property DTSID As String
    Public Property ExecutableType As String
    Public Property LastModifiedProductVersion As String
    Public Property LocaleID As String
    Public Property ObjectName As String
    Public Property PackageType As String
    Public Property VersionBuild As String
    Public Property VersionGUID As String


End Class
