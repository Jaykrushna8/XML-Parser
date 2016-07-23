Imports System.Data.SqlClient
Module Module1
    Public Sub Main()
        Dim xDoc As MSXML.DOMDocument
        xDoc = New MSXML.DOMDocument
        xDoc.validateOnParse = False
        If xDoc.load("D:\Study\Advanced Database CIS 612\test.xml") Then
            ' The document loaded successfully.
            ' Now do something intersting.
            DisplayNode(xDoc.childNodes, 0)
            Console.Write("Done1")
            Storingdata()

        Else
            ' The document failed to load.
            Dim strErrText As String
            Dim xPE As MSXML.IXMLDOMParseError
            ' Obtain the ParseError object
            xPE = xDoc.parseError
            With xPE
                strErrText = "Your XML Document failed to load" & _
                  "due the following error." & vbCrLf & _
                  "Error #: " & .errorCode & ": " & xPE.reason & _
                  "Line #: " & .line & vbCrLf & _
                  "Line Position: " & .linepos & vbCrLf & _
                  "Position In File: " & .filepos & vbCrLf & _
                  "Source Text: " & .srcText & vbCrLf & _
                  "Document URL: " & .url
            End With

            MsgBox(strErrText, vbExclamation)
        End If

    End Sub
    Dim table As New DataTable

    Dim book As New DataTable
    Dim author As New DataTable

    Dim address As New DataTable
    Dim bib As New DataTable
    Dim temp1 As Integer
    Dim temp2 As Integer
    Dim temp15 As Integer
    Dim temp16 As Integer
    Dim temp17 As Integer = 0
    Dim i As Integer = 0
    Dim j As Integer = 0
    Dim k As Integer = 0
    Dim l As Integer = 0
    Dim m As Integer = 0
    Dim row As DataRow
    Dim row1 As DataRow
    Dim row2 As DataRow

    ' Recursive funcion that extract xml node and store in datatable 
    Public Sub DisplayNode(ByRef Nodes As MSXML.IXMLDOMNodeList, _
       ByVal Indent As Integer)


        Dim xNode As MSXML.IXMLDOMNode
        Indent = Indent + 2

        For Each xNode In Nodes

            If xNode.nodeType = DOMNodeType.NODE_ELEMENT Then
                If xNode.nodeName = "bib" Then
                    If bib.Columns.Contains("bibid") Then
                        'Console.Write("Already")
                    Else
                        bib.Columns.Add("bibid")
                        Console.Write(xNode.nodeName)
                    End If
                    If book.Columns.Contains("bibid") Then
                        'Console.Write("Already")
                    Else
                        book.Columns.Add("bibid")
                        m = m + 2
                        temp17 = m
                        Console.Write(xNode.nodeName)
                    End If
                    row2 = bib.NewRow()
                    l = l + 1
                    temp16 = l
                    
                End If
                If xNode.nodeName = "book" Then
                    If book.Columns.Contains("bookid") Then
                        'Console.Write("Already")
                    Else
                        book.Columns.Add("bookid")
                        Console.Write(xNode.nodeName)
                    End If
                    If book.Columns.Contains("price") Then
                        'Console.Write("Already")
                    Else
                        book.Columns.Add("price")
                        Console.Write(xNode.nodeName)
                    End If
                    row = book.NewRow()
                    If (IsNothing(xNode.attributes.getNamedItem("price"))) Then

                    Else
                        row("price") = CInt(xNode.attributes(0).nodeValue)
                    End If

                    i = i + 1
                    temp1 = i
                    row("bookid") = temp1
                    row2 = bib.NewRow()
                    row2("bibid") = temp16
                    bib.Rows.Add(row2)
                    Console.WriteLine(temp1)
                    Console.WriteLine(i)
                    Console.WriteLine(xNode.nodeName)
                End If
                If xNode.nodeName = "publisher" Then
                    If book.Columns.Contains(xNode.nodeName) Then
                        Console.Write("Already")
                    Else
                        book.Columns.Add(xNode.nodeName)
                        Console.Write(xNode.nodeName)
                    End If
                End If
                If xNode.nodeName = "author" Then
                    row1 = author.NewRow()
                    If author.Columns.Contains("authorid") Then
                        Console.Write("Already")

                    Else
                        author.Columns.Add("authorid")
                        Console.Write(xNode.nodeName)
                    End If
                    If author.Columns.Contains("bookid") Then
                        Console.Write("Already")

                    Else
                        author.Columns.Add("bookid")
                        Console.Write(xNode.nodeName)
                    End If
                    If author.Columns.Contains(xNode.nodeName) Then
                        Console.Write("Already")
                        author.Rows.Add(row1)
                    Else

                        author.Columns.Add(xNode.nodeName)
                        author.Rows.Add(row1)
                        Console.Write(xNode.nodeName)
                    End If
                    k = k + 1
                    temp15 = k
                    row1("authorid") = temp15
                    row1("bookid") = temp1
                End If
                If xNode.nodeName = "first-name" Then
                    If author.Columns.Contains(xNode.nodeName) Then
                        Console.Write("Already")
                    Else
                        author.Columns.Add(xNode.nodeName)
                        Console.Write(xNode.nodeName)
                    End If
                End If
                If xNode.nodeName = "last-name" Then
                    If author.Columns.Contains(xNode.nodeName) Then
                        Console.Write("Already")
                    Else
                        author.Columns.Add(xNode.nodeName)
                        Console.Write(xNode.nodeName)
                    End If
                End If
                If xNode.nodeName = "title" Then
                    If book.Columns.Contains(xNode.nodeName) Then
                        Console.Write("Already")
                    Else
                        book.Columns.Add(xNode.nodeName)
                        Console.Write(xNode.nodeName)
                    End If
                End If
                If xNode.nodeName = "year" Then
                    If book.Columns.Contains(xNode.nodeName) Then
                        Console.Write("Already")
                    Else
                        book.Columns.Add(xNode.nodeName)
                        Console.Write(xNode.nodeName)
                    End If
                End If
                If xNode.nodeName = "address" Then
                    If address.Columns.Contains(xNode.nodeName) Then
                        Console.Write("Already")
                    Else
                        address.Columns.Add(xNode.nodeName)
                        Console.Write(xNode.nodeName)
                    End If
                End If
                If xNode.nodeName = "street" Then
                    If author.Columns.Contains(xNode.nodeName) Then
                        Console.Write("Already")
                    Else
                        author.Columns.Add(xNode.nodeName)
                        Console.Write(xNode.nodeName)
                    End If
                End If
                If xNode.nodeName = "zip" Then
                    If author.Columns.Contains(xNode.nodeName) Then
                        Console.Write("Already")
                    Else
                        author.Columns.Add(xNode.nodeName)
                        Console.Write(xNode.nodeName)
                    End If
                End If
                If xNode.nodeName = "name" Then
                    If author.Columns.Contains(xNode.nodeName) Then
                        Console.Write("Already")
                    Else
                        author.Columns.Add(xNode.nodeName)
                        Console.Write(xNode.nodeName)
                    End If
                End If
                If xNode.nodeName = "paper" Then
                    If book.Columns.Contains("paperid") Then
                        'Console.Write("Already")
                    Else
                        book.Columns.Add("paperid")
                        Console.Write(xNode.nodeName)
                    End If

                    j = j + 1
                    temp2 = j
                    row = book.NewRow()
                    row("bookid") = 0
                    row("paperid") = temp2
                    row("bibid") = temp17
                    If (IsNothing(xNode.attributes.getNamedItem("price"))) Then

                    Else
                        row("price") = CInt(xNode.attributes(0).nodeValue)
                    End If
                    Console.WriteLine("Suceessful")


                End If
            End If
            If xNode.nodeType = DOMNodeType.NODE_TEXT Then
                '
                If xNode.parentNode.nodeName = "publisher" Then

                    row("publisher") = xNode.nodeValue

                    Console.WriteLine(row("publisher"))
                ElseIf xNode.parentNode.nodeName = "author" Then

                    row1("author") = xNode.nodeValue

                    Console.WriteLine(xNode.nodeValue)
                ElseIf xNode.parentNode.nodeName = "first-name" Then
                    row1("first-name") = xNode.nodeValue

                    Console.WriteLine(xNode.nodeValue)

                ElseIf xNode.parentNode.nodeName = "last-name" Then
                    row1("last-name") = xNode.nodeValue

                    Console.WriteLine(xNode.nodeValue)
                ElseIf xNode.parentNode.nodeName = "title" Then
                    row("title") = xNode.nodeValue

                    Console.WriteLine(xNode.nodeValue)
                ElseIf xNode.parentNode.nodeName = "year" Then
                    row("year") = xNode.nodeValue


                    Console.WriteLine(xNode.nodeValue)
                    book.Rows.Add(row)

                    Console.WriteLine("Suceess")
                ElseIf xNode.parentNode.nodeName = "address" Then

                    address.Rows.Add(xNode.nodeValue)
                    Console.WriteLine(xNode.nodeValue)
                ElseIf xNode.parentNode.nodeName = "street" Then
                    row1("street") = xNode.nodeValue

                    Console.WriteLine(xNode.nodeValue)

                ElseIf xNode.parentNode.nodeName = "zip" Then
                    row1("zip") = xNode.nodeValue

                    Console.WriteLine(xNode.nodeValue)
                ElseIf xNode.parentNode.nodeName = "name" Then
                    row1("name") = xNode.nodeValue

                    Console.WriteLine(xNode.nodeValue)


                End If

            End If

            If xNode.hasChildNodes Then
                DisplayNode(xNode.childNodes, Indent)
            End If
        Next xNode

    End Sub
    ' This function create sql connection and store all data to sql database
    Public Sub Storingdata()
        Dim myconn As SqlConnection
        Dim mycmd As SqlCommand



        Console.WriteLine(temp2)
        Console.WriteLine(temp15)
        Console.WriteLine(book.Rows(4)("publisher").ToString)

        Dim temp11 As Integer = author.Rows.Count

        Try
            myconn = New SqlConnection("Data Source=JAYKRUSHNA;Initial Catalog=Bibs;Integrated Security=True")
            myconn.Open()
            ' store data to book table
            For index As Integer = 0 To temp1 - 1


                mycmd = New SqlCommand("Xmltoconvert", myconn)
                mycmd.CommandText = "XmltoConvert"
                mycmd.CommandType = CommandType.StoredProcedure
                mycmd.Parameters.AddWithValue("@bibid", bib.Rows(index)("bibid").ToString)
                mycmd.Parameters.AddWithValue("@bookid", book.Rows(index)("bookid").ToString)
                mycmd.Parameters.AddWithValue("@Publisher", book.Rows(index)("publisher").ToString)



                mycmd.Parameters.AddWithValue("@Title", book.Rows(index)("title").ToString)

                mycmd.Parameters.AddWithValue("@Year", book.Rows(index)("year").ToString)
                mycmd.Parameters.AddWithValue("@Price", book.Rows(index)("price").ToString)


                mycmd.ExecuteNonQuery()
                Console.WriteLine("Done Suceesfully")
            Next
            ' store data to author table
            For index2 As Integer = 0 To temp15 - 1


                mycmd = New SqlCommand("Xmltoconvert2", myconn)
                mycmd.CommandText = "XmltoConvert2"
                mycmd.CommandType = CommandType.StoredProcedure
                mycmd.Parameters.AddWithValue("@bookid", author.Rows(index2)("bookid").ToString)
                mycmd.Parameters.AddWithValue("@author", author.Rows(index2)("author").ToString)
                mycmd.Parameters.AddWithValue("@firstname", author.Rows(index2)("first-name").ToString)
                mycmd.Parameters.AddWithValue("@lastname", author.Rows(index2)("last-name").ToString)

                mycmd.Parameters.AddWithValue("@street", author.Rows(index2)("street").ToString)
                mycmd.Parameters.AddWithValue("@zip", author.Rows(index2)("zip").ToString)
                mycmd.Parameters.AddWithValue("@name", author.Rows(index2)("name").ToString)
                mycmd.ExecuteNonQuery()
                Console.WriteLine("DOne")
            Next
            Console.WriteLine(temp1 + temp2)
            ' store data to paper table
            For index1 As Integer = 4 To temp2 + temp1


                mycmd = New SqlCommand("Xmltoconvert1", myconn)
                mycmd.CommandText = "XmltoConvert1"
                mycmd.CommandType = CommandType.StoredProcedure
                mycmd.Parameters.AddWithValue("@bibid", book.Rows(index1)("bibid").ToString)
                mycmd.Parameters.AddWithValue("@paperid", book.Rows(index1)("paperid").ToString)
                mycmd.Parameters.AddWithValue("@Publisher", book.Rows(index1)("publisher").ToString)
                mycmd.Parameters.AddWithValue("@Title", book.Rows(index1)("title").ToString)
                mycmd.Parameters.AddWithValue("@Year", book.Rows(index1)("year").ToString)
                mycmd.Parameters.AddWithValue("@Price", book.Rows(index1)("price").ToString)

                mycmd.ExecuteNonQuery()
                Console.WriteLine("DOne")
            Next
        Catch ex As Exception
            Console.Write(ex)

        End Try
    End Sub





End Module
