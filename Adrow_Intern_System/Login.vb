Public Class frmLogin
    Dim LastName, FirstName, MiddleName, FullName As String
    Dim InternID As Int32
    Dim InternList As New Dictionary(Of String, String)()
    Dim DateNow As Date = DateTime.Now.ToString()
    Dim TimeNow As Date = DateTime.Now.ToString("hh:mm:ss")
    Dim LogStatus As String
    Public Sub GetIntern()
        qry = "SELECT ID, LastName, FirstName, MiddleName FROM Interns WHERE IsDeleted=0;"
        dt = ExecuteQuery(qry)
        If dt.Rows.Count > 0 Then
            cbFullname.Items.Clear()
            'InternList.Add(-1, "Intern Name")
            For Each value In dt.Rows
                InternID = Convert.ToInt32(value("ID"))
                LastName = value("LastName")
                FirstName = value("FirstName")
                MiddleName = value("MiddleName")
                FullName = FirstName + " " + MiddleName + " " + LastName
                cbFullname.Items.Add(FullName)
                'cbFullname.Items.Insert(InternID, FullName)
                InternList.Add(FullName, InternID)
            Next
            'cbFullname.DataSource = New BindingSource(InternList, Nothing)
            'cbFullname.DisplayMember = "Value"
            'cbFullname.ValueMember = "Key"
        End If
    End Sub

    Private Sub cbFullname_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbFullname.SelectedIndexChanged
        btnLog.Enabled = True
        Dim name As String = cbFullname.SelectedItem
        Dim id As Int32 = InternList.Item(name)
        qry = "SELECT LogStatus FROM InternLog WHERE InternID='" & id & "' AND LogDate='" & DateNow & "' AND LogStatus='Login';"
        dt = ExecuteQuery(qry)
        If dt.Rows.Count > 0 Then
            btnLog.Text = "Logout"
        Else
            MsgBox(dt.Rows(0)(0).ToString)
            'If dt.Rows(0)(0).ToString = "Logout" Then
            '    btnLog.Text = "Stop"
            'Else
            '    btnLog.Text = "Login"
            'End If
        End If
    End Sub

    Private Sub btnLog_Click(sender As Object, e As EventArgs) Handles btnLog.Click
        'Dim id As String = DirectCast(cbFullname.SelectedItem, KeyValuePair(Of String, String)).Key
        'Dim value As String = DirectCast(cbFullname.SelectedItem, KeyValuePair(Of String, String)).Value
        Dim name As String = cbFullname.SelectedItem
        Dim id As Int32 = InternList.Item(name)
        Dim LastName, Gender, CivilStatus, PrefixName As String
        'qry = "INSERT INTO InternLog (
        '        InternID,
        '        LogDate,
        '        LogStatus
        '    ) VALUES ('" & id & "',
        '        '" & LogDate & "',
        '        '" & LogStatus & "');"
        'qry = "SELECT * FROM InternLog WHERE InternID='" & id & "' AND LogDate='" & LogDate & "' AND LogStatus='Login';"
        'qry = "INSERT INTO InternLog (InternID, LogDate, LogStatus) VALUES ('" & id & "', '" & LogDate & "', 'Login');"
        'If InternList.ContainsKey(name) Then
        '    InternList.Item(name)
        'Else
        '    MsgBox("Nothing")
        'End If
        qry = "SELECT LastName, Gender, CivilStatus From Interns WHERE ID='" & id & "';"
        Try
            dt = ExecuteQuery(qry)
            LastName = dt.Rows(0)(0).ToString
            Gender = dt.Rows(0)(1).ToString
            CivilStatus = dt.Rows(0)(2).ToString
        Catch ex As Exception
            MsgBox(ex, MessageBoxIcon.Exclamation, "Error")
            Exit Sub
        End Try

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

        If btnLog.Text = "Login" Then
            qry = "INSERT INTO InternLog (InternID, LogDate, LoginTime, LogStatus) VALUES ('" & id & "', '" & DateNow & "', '" & TimeNow & "', 'Login')"
            Try
                ExecuteQuery(qry)
                MsgBox("You are now login " + PrefixName + " " + LastName + "")
            Catch ex As Exception
                MsgBox("Login Intern Failed!", MessageBoxIcon.Exclamation, "Error")
                Exit Sub
            End Try
        ElseIf btnLog.Text = "Logout" Then
            qry = "SELECT ID FROM InternLog WHERE InternID='" & id & "' AND LogDate='" & DateNow & "' AND LogStatus='Login';"
            Try
                dt = ExecuteQuery(qry)
                Dim logid = dt.Rows(0)(0).ToString
                qry = "UPDATE InternLog SET LogoutTime = '" & TimeNow & "', LogStatus = 'Logout' WHERE ID = '" & logid & "';"
                Try
                    ExecuteQuery(qry)
                    MsgBox("You are now logout " + PrefixName + " " + LastName + "")
                Catch ex As Exception
                    MsgBox("Logout Intern Failed!", MessageBoxIcon.Exclamation, "Error")
                    Exit Sub
                End Try
            Catch ex As Exception
                MsgBox(ex, MessageBoxIcon.Exclamation, "Error")
                Exit Sub
            End Try
        End If

        Try
            'dt = ExecuteQuery(qry)
            'MsgBox(dt.Rows.Count)
            'MsgBox(LogDate)
            'ExecuteQuery(qry)

        Catch ex As Exception
            MsgBox("Adding New Intern Failed!", MessageBoxIcon.Exclamation, "Error")
            Exit Sub
        End Try
    End Sub

    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tmrDateAndTime.Start()
        GetIntern()
        btnLog.Enabled = False
    End Sub

    Private Sub tmrDateAndTime_Tick(sender As Object, e As EventArgs) Handles tmrDateAndTime.Tick
        lblDateAndTime.Text = DateTime.Now.ToString()
    End Sub

    Private Sub btnAdmin_Click(sender As Object, e As EventArgs) Handles btnAdmin.Click
        Me.Hide()
        frmMain.Show()
    End Sub
End Class