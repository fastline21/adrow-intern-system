Public Class frmEditIntern
    Public ID As Int32
    Private LastName, FirstName, MiddleName, CompleteAddress, Gender, CivilStatus, PrefixName, School, Course, NoOfHours, UserCreated As String

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        ' Define Variable
        Dim NoOfHours As Integer
        Dim DateCreated As Date
        Dim IsDeleted As Boolean

        ' Validate all Textbox
        If txtLastName.Text = "" Then
            MsgBox("Please fill out this field", vbOKOnly, "Require")
            txtLastName.Select()
            Exit Sub
        Else
            If txtFirstName.Text = "" Then
                MsgBox("Please fill out this field", vbOKOnly, "Require")
                txtFirstName.Select()
                Exit Sub
            Else
                If txtMiddleName.Text = "" Then
                    MsgBox("Please fill out this field", vbOKOnly, "Require")
                    txtMiddleName.Select()
                    Exit Sub
                Else
                    If txtCompleteAddress.Text = "" Then
                        MsgBox("Please fill out this field", vbOKOnly, "Require")
                        txtCompleteAddress.Select()
                        Exit Sub
                    Else
                        If cbGender.Text = "" Then
                            MsgBox("Please fill out this field", vbOKOnly, "Require")
                            cbGender.Select()
                            Exit Sub
                        Else
                            If cbCivilStatus.Text = "" Then
                                MsgBox("Please fill out this field", vbOKOnly, "Require")
                                cbCivilStatus.Select()
                                Exit Sub
                            Else
                                If txtSchool.Text = "" Then
                                    MsgBox("Please fill out this field", vbOKOnly, "Require")
                                    txtSchool.Select()
                                    Exit Sub
                                Else
                                    If txtCourse.Text = "" Then
                                        MsgBox("Please fill out this field", vbOKOnly, "Require")
                                        txtCourse.Select()
                                        Exit Sub
                                    Else
                                        If txtNoOfHours.Text = "" Then
                                            MsgBox("Please fill out this field", vbOKOnly, "Require")
                                            txtNoOfHours.Select()
                                            Exit Sub
                                        ElseIf Not IsNumeric(txtNoOfHours.Text) Then
                                            MsgBox("Please input only numbers", vbOKOnly, "Error")
                                            txtNoOfHours.Select()
                                            Exit Sub
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        End If

        ' Get all Textbox Value
        LastName = txtLastName.Text
        FirstName = txtFirstName.Text
        MiddleName = txtMiddleName.Text
        CompleteAddress = txtCompleteAddress.Text
        Gender = cbGender.Text
        CivilStatus = cbCivilStatus.Text
        School = txtSchool.Text
        Course = txtCourse.Text
        NoOfHours = txtNoOfHours.Text
        IsDeleted = False
        UserCreated = "Admin"

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

        ' Get Empty No of Hours
        'If Not Int32.TryParse(txtNoOfHours.Text, NoOfHours) Then
        'NoOfHours = 0
        'End If

        ' Get Date and Time
        DateCreated = DateTime.Now.ToString()

        ' Exist Data Query
        'qry = "SELECT * FROM Interns WHERE LastName='" & LastName & "' AND FirstName='" & FirstName & "' AND MiddleName='" & MiddleName & "' AND IsDeleted='" & IsDeleted & "';"

        Dim result = MsgBox("Are you sure you want to save?", vbYesNo, PrefixName + " " + LastName)
        qry = "UPDATE Interns SET 
            LastName = '" & LastName & "', 
            FirstName = '" & FirstName & "',
            MiddleName = '" & MiddleName & "',
            CompleteAddress = '" & CompleteAddress & "',
            Gender = '" & Gender & "',
            CivilStatus = '" & CivilStatus & "',
            School = '" & School & "',
            Course = '" & Course & "',
            NoOfHours = '" & NoOfHours & "'
            WHERE ID = '" & ID & "';"
        If result = vbYes Then
            Try
                ExecuteQuery(qry)
                MsgBox("Updating Intern Success!", vbOKOnly, "Intern Success")
                Me.Close()
                frmMain.RefreshListView()
                frmMain.btnAddIntern.Enabled = True
                frmMain.btnEditIntern.Enabled = False
                frmMain.btnDeleteIntern.Enabled = False
            Catch ex As Exception
                MsgBox("Updating Intern Failed!", MessageBoxIcon.Exclamation, "Error")
                Exit Sub
            End Try
        Else
            txtLastName.Select()
        End If
    End Sub

    Public Sub GetIntern(ID)
        qry = "SELECT * FROM Interns WHERE ID='" & ID & "';"
        dt = ExecuteQuery(qry)
        If dt.Rows.Count > 0 Then
            LastName = dt.Rows(0)(1).ToString
            FirstName = dt.Rows(0)(2).ToString
            MiddleName = dt.Rows(0)(3).ToString
            CompleteAddress = dt.Rows(0)(4).ToString
            Gender = dt.Rows(0)(5).ToString
            CivilStatus = dt.Rows(0)(6).ToString
            School = dt.Rows(0)(7).ToString
            Course = dt.Rows(0)(8).ToString
            NoOfHours = dt.Rows(0)(9).ToString
        End If
    End Sub
    Private Sub frmEditIntern_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtLastName.Text = LastName
        txtFirstName.Text = FirstName
        txtMiddleName.Text = MiddleName
        txtCompleteAddress.Text = CompleteAddress
        cbGender.Text = Gender
        cbCivilStatus.Text = CivilStatus
        txtSchool.Text = School
        txtCourse.Text = Course
        txtNoOfHours.Text = NoOfHours
    End Sub
End Class