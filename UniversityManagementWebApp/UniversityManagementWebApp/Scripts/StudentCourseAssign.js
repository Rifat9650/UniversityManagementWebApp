$(document).ready(function () {
    $("#registrationNoDropDownList").change(function () {
        //$("")

        var studentId = $("#registrationNoDropDownList").val();
        var jasnData = { Id: studentId };

        $.ajax({

            type: "POST",
            url: '/CourseEnroll/GetStudentInfoById',
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(jasnData),
            dataType: "json",
            success: function (data) {
                $("#nameTextBox").val(data["Name"]);
                $("#emailTextBox").val(data["Email"]);
                $("#departmentTextBox").val(data["DepartmentName"]);
                document.getElementById("departmentTextBox").classList.add(data["DepartmentId"]);
                console.log(data);

            },
            complete: function () {
                var departmentId = parseInt(document.getElementById("departmentTextBox").classList[0], 10);
                document.getElementById("departmentTextBox").classList.remove(departmentId);

                console.log(departmentId);
                var jsnData = { id: departmentId };
                $.ajax({

                    type: "POST",
                    url: '/CourseEnroll/GetCoursesById',
                    contentType: "application/json; charset=utf-8",
                    data: JSON.stringify(jsnData),
                    dataType: "json",
                    success: function (data) {

                        $("#courseDropDownList").empty().append("<option value='0'>--Select--</option>");
                        $.each(data, function (key, value) {
                            $("#courseDropDownList").append("<option value=" + value.Id + ">" + value.Code + "</option>");
                        });
                    }
                });
            }
        });

    });
});

