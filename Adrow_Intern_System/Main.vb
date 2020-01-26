Public Class frmMain
    Public Sub RefreshListView()
        qry = "SELECT ID, LastName, FirstName, MiddleName, School FROM Interns WHERE IsDeleted=0;"
        dt = ExecuteQuery(qry)
        FillListView(dt, lvIntern)

        'Set Column Header Name and Width
        lvIntern.Columns(0).Text = "ID"
        lvIntern.Columns(1).Text = "Last Name"
        lvIntern.Columns(2).Text = "First Name"
        lvIntern.Columns(3).Text = "Middle Name"
        lvIntern.Columns(4).Text = "School"
        lvIntern.Columns(0).Width = -2
        lvIntern.Columns(1).Width = -2
        lvIntern.Columns(2).Width = -2
        lvIntern.Columns(3).Width = -2
        lvIntern.Columns(4).Width = -2
    End Sub
    Private Sub btnAddIntern_Click(sender As Object, e As EventArgs) Handles btnAddIntern.Click
        frmAddIntern.ShowDialog()
    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tmrIntern.Start()
        RefreshListView()
        btnAddIntern.Enabled = True
        btnEditIntern.Enabled = False
        btnDeleteIntern.Enabled = False
    End Sub

    Private Sub btnEditIntern_Click(sender As Object, e As EventArgs) Handles btnEditIntern.Click
        frmEditIntern.GetIntern(lvIntern.SelectedItems(0).SubItems(0).Text)
        frmEditIntern.ID = lvIntern.SelectedItems(0).SubItems(0).Text
        frmEditIntern.ShowDialog()
    End Sub

    Private Sub lvIntern_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvIntern.SelectedIndexChanged
        If lvIntern.SelectedItems.Count > 0 Then
            btnAddIntern.Enabled = False
            btnEditIntern.Enabled = True
            btnDeleteIntern.Enabled = True
        Else
            btnAddIntern.Enabled = True
            btnEditIntern.Enabled = False
            btnDeleteIntern.Enabled = False
        End If
    End Sub

    Private Sub frmMain_Click(sender As Object, e As EventArgs) Handles Me.Click
        lvIntern.SelectedItems.Clear()
    End Sub

    Private Sub tmrIntern_Tick(sender As Object, e As EventArgs) Handles tmrIntern.Tick
        RefreshListView()
        lvIntern.SelectedItems.Clear()
    End Sub

    Private Sub btnDeleteIntern_Click(sender As Object, e As EventArgs) Handles btnDeleteIntern.Click
        Dim ID As Int32 = lvIntern.SelectedItems(0).SubItems(0).Text
        Dim LastName, Gender, CivilStatus, PrefixName As String
        qry = "SELECT * FROM Interns WHERE ID='" & ID & "';"
        dt = ExecuteQuery(qry)
        If dt.Rows.Count > 0 Then
            LastName = dt.Rows(0)(1).ToString
            Gender = dt.Rows(0)(5).ToString
            CivilStatus = dt.Rows(0)(6).ToString
        End If
        Select Case Gender
            Case "Male"
                PrefixName = "Mr."
            Case "Female"
                Select Case CivilStatus
                    Case "Single"
                        PrefixName = "Ms."
                    Case "Married"
                        PrefixName = "Mrs."
                    Case "Divorced"
                        PrefixName = "Ms."
                    Case "Widowed"
                        PrefixName = "Mrs."
                End Select
        End Select
        Dim result = MsgBox("Are you sure to delete " + PrefixName + " " + LastName + "?", vbYesNo, "Delete Intern")
        If result = vbYes Then
            qry = "UPDATE Interns SET IsDeleted = 1 WHERE ID = '" & ID & "';"
            ExecuteQuery(qry)
            MsgBox("Deleting Intern Success!", vbOKOnly, "Success")
            RefreshListView()
            lvIntern.SelectedItems.Clear()
            btnAddIntern.Enabled = True
            btnEditIntern.Enabled = False
            btnDeleteIntern.Enabled = False
        Else
            lvIntern.SelectedItems.Clear()
            btnAddIntern.Enabled = True
            btnEditIntern.Enabled = False
            btnDeleteIntern.Enabled = False
        End If
    End Sub
End Class
