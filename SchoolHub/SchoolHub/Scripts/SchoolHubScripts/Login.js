$(document).ready(function () {
    $("#submit").click(function (e) {
        if ($("#username").val() == "")
            alert("Username cannot be empty");
        else if ($("#password").val() == "")
            alert("Password cannot be empty");
        else {
            $.ajax({
                type: "POST",
                url: "/Login/CheckUserLogin",
                contentType: "application/json; charset=utf-8",
                data: '{"username":"' + $("#username").val() + '","password":"' + $("#password").val() + '"}',
                dataType: "html",
                success: function (result, status, xhr) {
                    out = JSON.parse(result)
                    if (out.message != "") {
                        alert(out.message)
                    } else {
                        if (out.user.RoleId == 1) {
                            var teacherId = out.user.Id;
                            window.location.href = '@Url.Action("Index", "TeacherHome", new { username = '+$("#username").val()+', password = '+$("#password").val()+' })';
                        } else {
                            window.location.href = '@Url.Action("Index", "StudentHome")';
                        }
                    }
                },
                error: function (xhr, status, error) {
                    alert("Issue occured while logging in")
                }
            });
        }
        return false;
    });
});
  