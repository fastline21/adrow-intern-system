Imports System.Data.SqlClient
Module mdlConnection
    Public dt As DataTable
    Public con As String = "Data Source=DESKTOP-FC617RR\SQLEXPRESS;Initial Catalog=adrowInternSystemDB;User ID=sa;Password=master"
    Public con1 As SqlConnection = New SqlConnection(con)
    Public qry As String
    Public Sub FillListView(ByVal dt As DataTable, ByVal lv As ListView)
        Try
            lv.Items.Clear()
            lv.Columns.Clear()
            Dim i As Integer
            Dim j As Integer
            For i = 0 To dt.Columns.Count - 1
                lv.Columns.Add(dt.Columns(i).ColumnName)
            Next i
            For i = 0 To dt.Rows.Count - 1
                lv.Items.Add(dt.Rows(i).Item(0))
                For j = 1 To dt.Columns.Count - 1
                    lv.Items(i).SubItems.Add(dt.Rows(i).Item(j))
                Next j
            Next i
            For i = 0 To dt.Columns.Count - 1
                lv.Columns(i).AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize)
            Next i
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Public Function ExecuteQuery(ByVal query As String) As DataTable
        Try
            Dim sqlDA As New SqlDataAdapter(query, con)
            Dim sqlCB As New SqlCommandBuilder(sqlDA)
            Dim sqlDT As New DataTable
            sqlDA.Fill(sqlDT)
            Return sqlDT
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return Nothing
        End Try
    End Function
    Public Function IfExist(ByVal sql As String) As Boolean
        Dim ok As Boolean = False
        Try
            If con1.State = ConnectionState.Open Then
                con1.Close()
                con1.Open()
            Else
                con1.Open()
            End If
            Dim cmd As SqlCommand = New SqlCommand(sql, con1)
            Dim rdr As SqlDataReader = cmd.ExecuteReader
            If rdr.Read Then
                ok = True
            End If
        Catch ex As Exception
            MsgBox("Invalid Input!")
        Finally
            con1.Close()
        End Try
        Return ok
    End Function
End Module
