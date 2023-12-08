Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Web
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Namespace SMS
    Friend Module API
        Private ReadOnly Server As String = "https://tuaguidance.online"
        Private ReadOnly Key As String = "150b7e82881d08f5ea06f6aeff28c073feab912a"

        Public Enum [Option]
            USE_SPECIFIED = 0
            USE_ALL_DEVICES = 1
            USE_ALL_SIMS = 2
        End Enum


        Public Function SendSingleMessage(ByVal number As String, ByVal message As String, ByVal Optional device As String = "0", ByVal Optional schedule As Long? = Nothing, ByVal Optional isMMS As Boolean = False, ByVal Optional attachments As String = Nothing, ByVal Optional prioritize As Boolean = False) As Dictionary(Of String, Object)
            Dim values = New Dictionary(Of String, Object) From {
    {"number", number},
    {"message", message},
    {"schedule", schedule},
    {"key", Key},
    {"devices", device},
    {"type", If(isMMS, "mms", "sms")},
    {"attachments", attachments},
    {"prioritize", If(prioritize, 1, 0)}
}

            Return GetObjects(GetResponse($"{Server}/services/send.php", values)("messages"))(0)
        End Function


        Public Function SendMessages(ByVal messages As List(Of Dictionary(Of String, String)), ByVal Optional [option] As [Option] = [Option].USE_SPECIFIED, ByVal Optional devices As String() = Nothing, ByVal Optional schedule As Long? = Nothing, ByVal Optional useRandomDevice As Boolean = False) As Dictionary(Of String, Object)()
            Dim values = New Dictionary(Of String, Object) From {
    {"messages", JsonConvert.SerializeObject(messages)},
    {"schedule", schedule},
    {"key", Key},
    {"devices", devices},
    {"option", CInt([option])},
    {"useRandomDevice", useRandomDevice}
}

            Return GetObjects(GetResponse($"{Server}/services/send.php", values)("messages"))
        End Function


        Public Function SendMessageToContactsList(ByVal listID As Integer, ByVal message As String, ByVal Optional [option] As [Option] = [Option].USE_SPECIFIED, ByVal Optional devices As String() = Nothing, ByVal Optional schedule As Long? = Nothing, ByVal Optional isMMS As Boolean = False, ByVal Optional attachments As String = Nothing) As Dictionary(Of String, Object)()
            Dim values = New Dictionary(Of String, Object) From {
    {"listID", listID},
    {"message", message},
    {"schedule", schedule},
    {"key", Key},
    {"devices", devices},
    {"option", CInt([option])},
    {"type", If(isMMS, "mms", "sms")},
    {"attachments", attachments}
}

            Return GetObjects(GetResponse($"{Server}/services/send.php", values)("messages"))
        End Function


        Public Function GetMessageByID(ByVal id As Integer) As Dictionary(Of String, Object)
            Dim values = New Dictionary(Of String, Object) From {
    {"key", Key},
    {"id", id}
}

            Return GetObjects(GetResponse($"{Server}/services/read-messages.php", values)("messages"))(0)
        End Function


        Public Function GetMessagesByGroupID(ByVal groupID As String) As Dictionary(Of String, Object)()
            Dim values = New Dictionary(Of String, Object) From {
    {"key", Key},
    {"groupId", groupID}
}

            Return GetObjects(GetResponse($"{Server}/services/read-messages.php", values)("messages"))
        End Function


        Public Function GetMessagesByStatus(ByVal status As String, ByVal Optional deviceID As Integer? = Nothing, ByVal Optional simSlot As Integer? = Nothing, ByVal Optional startTimestamp As Long? = Nothing, ByVal Optional endTimestamp As Long? = Nothing) As Dictionary(Of String, Object)()
            Dim values = New Dictionary(Of String, Object) From {
    {"key", Key},
    {"status", status},
    {"deviceID", deviceID},
    {"simSlot", simSlot},
    {"startTimestamp", startTimestamp},
    {"endTimestamp", endTimestamp}
}

            Return GetObjects(GetResponse($"{Server}/services/read-messages.php", values)("messages"))
        End Function


        Public Function ResendMessageByID(ByVal id As Integer) As Dictionary(Of String, Object)
            Dim values = New Dictionary(Of String, Object) From {
    {"key", Key},
    {"id", id}
}

            Return GetObjects(GetResponse($"{Server}/services/resend.php", values)("messages"))(0)
        End Function


        Public Function ResendMessagesByGroupID(ByVal groupID As String, ByVal Optional status As String = Nothing) As Dictionary(Of String, Object)()
            Dim values = New Dictionary(Of String, Object) From {
    {"key", Key},
    {"groupId", groupID},
    {"status", status}
}

            Return GetObjects(GetResponse($"{Server}/services/resend.php", values)("messages"))
        End Function


        Public Function ResendMessagesByStatus(ByVal status As String, ByVal Optional deviceID As Integer? = Nothing, ByVal Optional simSlot As Integer? = Nothing, ByVal Optional startTimestamp As Long? = Nothing, ByVal Optional endTimestamp As Long? = Nothing) As Dictionary(Of String, Object)()
            Dim values = New Dictionary(Of String, Object) From {
    {"key", Key},
    {"status", status},
    {"deviceID", deviceID},
    {"simSlot", simSlot},
    {"startTimestamp", startTimestamp},
    {"endTimestamp", endTimestamp}
}

            Return GetObjects(GetResponse($"{Server}/services/resend.php", values)("messages"))
        End Function


        Public Function AddContact(ByVal listID As Integer, ByVal number As String, ByVal Optional name As String = Nothing, ByVal Optional resubscribe As Boolean = False) As Dictionary(Of String, Object)
            Dim values = New Dictionary(Of String, Object) From {
    {"key", Key},
    {"listID", listID},
    {"number", number},
    {"name", name},
    {"resubscribe", If(resubscribe, "1"c, "0"c)}
}
            Dim jObject As JObject = CType(GetResponse($"{Server}/services/manage-contacts.php", values)("contact"), JObject)
            Return jObject.ToObject(Of Dictionary(Of String, Object))()
        End Function


        Public Function UnsubscribeContact(ByVal listID As Integer, ByVal number As String) As Dictionary(Of String, Object)
            Dim values = New Dictionary(Of String, Object) From {
    {"key", Key},
    {"listID", listID},
    {"number", number},
    {"unsubscribe", "1"c}
}
            Dim jObject As JObject = CType(GetResponse($"{Server}/services/manage-contacts.php", values)("contact"), JObject)
            Return jObject.ToObject(Of Dictionary(Of String, Object))()
        End Function

        ''' <summary>
        ''' Get remaining message credits.
        ''' </summary>
        ''' <exception>If there is an error while getting message credits.</exception>
        ''' <returns>The amount of message credits left.</returns>
        Public Function GetBalance() As String
            Dim values = New Dictionary(Of String, Object) From {
    {"key", Key}
}
            Dim credits As JToken = GetResponse($"{Server}/services/send.php", values)("credits")
            Select Case credits.Type
                Case Is <> JTokenType.Null
                    Return credits.ToString()
                Case Else

                    Return "Unlimited"
            End Select
        End Function


        Public Function SendUssdRequest(ByVal request As String, ByVal device As Integer, ByVal Optional simSlot As Integer? = Nothing) As Dictionary(Of String, Object)
            Dim values = New Dictionary(Of String, Object) From {
    {"key", Key},
    {"request", request},
    {"device", device},
    {"sim", simSlot}
}

            Dim jObject As JObject = CType(GetResponse($"{Server}/services/send-ussd-request.php", values)("request"), JObject)
            Return jObject.ToObject(Of Dictionary(Of String, Object))()
        End Function


        Public Function GetUssdRequestByID(ByVal id As Integer) As Dictionary(Of String, Object)
            Dim values = New Dictionary(Of String, Object) From {
    {"key", Key},
    {"id", id}
}

            Return GetObjects(GetResponse($"{Server}/services/read-ussd-requests.php", values)("requests"))(0)
        End Function


        Public Function GetUssdRequests(ByVal request As String, ByVal Optional deviceID As Integer? = Nothing, ByVal Optional simSlot As Integer? = Nothing, ByVal Optional startTimestamp As Integer? = Nothing, ByVal Optional endTimestamp As Integer? = Nothing) As Dictionary(Of String, Object)()
            Dim values = New Dictionary(Of String, Object) From {
    {"key", Key},
    {"request", request},
    {"deviceID", deviceID},
    {"simSlot", simSlot},
    {"startTimestamp", startTimestamp},
    {"endTimestamp", endTimestamp}
}

            Return GetObjects(GetResponse($"{Server}/services/read-ussd-requests.php", values)("requests"))
        End Function


        Public Function GetDevices() As Dictionary(Of String, Object)()
            Dim values = New Dictionary(Of String, Object) From {
    {"key", Key}
}

            Return GetObjects(GetResponse($"{Server}/services/get-devices.php", values)("devices"))
        End Function

        Private Function GetObjects(ByVal messagesJToken As JToken) As Dictionary(Of String, Object)()
            Dim jArray As JArray = CType(messagesJToken, JArray)
            Dim messages = New Dictionary(Of String, Object)(jArray.Count - 1) {}
            For index = 0 To jArray.Count - 1
                messages(index) = jArray(index).ToObject(Of Dictionary(Of String, Object))()
            Next

            Return messages
        End Function

        Private Function GetResponse(ByVal url As String, ByVal postData As Dictionary(Of String, Object)) As JToken
            Dim request = CType(WebRequest.Create(url), HttpWebRequest)
            Dim dataString = CreateDataString(postData)
            Dim data = Encoding.UTF8.GetBytes(dataString)

            request.Method = "POST"
            request.ContentType = "application/x-www-form-urlencoded"
            request.ContentLength = data.Length
            ServicePointManager.Expect100Continue = True
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
            Using stream = request.GetRequestStream()
                stream.Write(data, 0, data.Length)
            End Using

            Dim response = CType(request.GetResponse(), HttpWebResponse)

            If response.StatusCode = HttpStatusCode.OK Then
                Using streamReader As StreamReader = New StreamReader(response.GetResponseStream())
                    Dim jsonResponse = streamReader.ReadToEnd()
                    Try
                        Dim jObject As JObject = jObject.Parse(jsonResponse)
                        If CBool(jObject("success")) Then
                            Return jObject("data")
                        End If

                        Throw New Exception(jObject("error")("message").ToString())
                    Catch __unusedJsonReaderException1__ As JsonReaderException
                        If String.IsNullOrEmpty(jsonResponse) Then
                            Throw New InvalidDataException("Missing data in request. Please provide all the required information to send messages.")
                        End If

                        Throw New Exception(jsonResponse)
                    End Try
                End Using
            End If

            Throw New WebException($"HTTP Error : {CInt(response.StatusCode)} {response.StatusCode}")
        End Function

        Private Function CreateDataString(ByVal data As Dictionary(Of String, Object)) As String
            Dim dataString As StringBuilder = New StringBuilder()
            Dim first = True
            For Each obj In data
                If obj.Value IsNot Nothing Then
                    If first Then
                        first = False
                    Else
                        dataString.Append("&")
                    End If

                    dataString.Append(HttpUtility.UrlEncode(obj.Key))
                    dataString.Append("=")
                    dataString.Append(If(TypeOf obj.Value Is String(), HttpUtility.UrlEncode(JsonConvert.SerializeObject(obj.Value)), HttpUtility.UrlEncode(obj.Value.ToString())))
                End If
            Next

            Return dataString.ToString()
        End Function
    End Module
End Namespace
