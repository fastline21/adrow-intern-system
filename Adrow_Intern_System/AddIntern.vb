Public Class frmAddIntern
    Private Sub frmAddIntern_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        ' Define Variable
        Dim LastName, FirstName, MiddleName, CompleteAddress, Gender, CivilStatus, School, Course, UserCreated, PrefixName As String
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
        qry = "SELECT * FROM Interns WHERE LastName='" & LastName & "' AND FirstName='" & FirstName & "' AND MiddleName='" & MiddleName & "' AND IsDeleted='" & IsDeleted & "';"

        If IfExist(qry) Then
            MsgBox("Intern Exist", vbOKOnly, "Exist")
            txtLastName.ResetText()
            txtFirstName.ResetText()
            txtMiddleName.ResetText()
            txtCompleteAddress.ResetText()
            cbGender.Text = ""
            cbCivilStatus.Text = ""
            txtSchool.ResetText()
            txtCourse.ResetText()
            txtNoOfHours.ResetText()
        Else
            ' Add Data Query
            qry = "INSERT INTO Interns (LastName,
                FirstName,
                MiddleName,
                CompleteAddress,
                Gender,
                CivilStatus,
                School,
                Course,
                NoOfHours,
                IsDeleted,
                DateCreated,
                UserCreated) VALUES ('" & LastName & "',
                '" & FirstName & "',
                '" & MiddleName & "',
                '" & CompleteAddress & "',
                '" & Gender & "',
                '" & CivilStatus & "',
                '" & School & "',
                '" & Course & "',
                '" & NoOfHours & "',
                '" & IsDeleted & "',
                '" & DateCreated & "',
                '" & UserCreated & "');"

            Dim result = MsgBox("Are you sure you want to continue?", vbYesNo, PrefixName + " " + LastName)
            If result = vbYes Then
                Try
                    ExecuteQuery(qry)
                    MsgBox("Adding New Intern Success!", vbOKOnly, "Success")
                    txtLastName.ResetText()
                    txtFirstName.ResetText()
                    txtMiddleName.ResetText()
                    txtCompleteAddress.ResetText()
                    cbGender.Text = ""
                    cbCivilStatus.Text = ""
                    txtSchool.ResetText()
                    txtCourse.ResetText()
                    txtNoOfHours.ResetText()
                    Me.Close()
                    frmMain.RefreshListView()
                Catch ex As Exception
                    MsgBox("Adding New Intern Failed!", MessageBoxIcon.Exclamation, "Error")
                    Exit Sub
                End Try
            Else
                txtLastName.Select()
            End If
        End If
    End Sub
End Class