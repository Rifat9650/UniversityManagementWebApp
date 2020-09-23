
$(document).ready(function () {
    $("#staticsTable").hide();
    $("#departmentDropDownList").change(function () {
        //$("#teacherDropDownList").empty();
        var departmentId = $("#departmentDropDownList").val();
        var jasonData = { id: departmentId };

        $.ajax({

            type: "POST",
            url: '/Course/GetCoursesInformationById',
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(jasonData),
            dataType: "json",
            success: function (data) {
                $("#staticsTable").show();
                $("#tableBody").empty();
                console.log(data);
                $.each(data, function (key, value) {

                    $("#tableBody").append('<tr><td>' + value.Code + '</td><td>' + value.Name + '</td><td>' + value.Semester + '</td><td>' + value.TeacherName + '</td></tr>');

                });
            }

        });

    });
});