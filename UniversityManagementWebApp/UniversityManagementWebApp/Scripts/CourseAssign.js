
$(document).ready(function () {


    $("#departmentDropDownList").change(function () {
        $("#teacherDropDownList").empty();
        var departmentId = $("#departmentDropDownList").val();
        console.log(departmentId);
        var jasonData = { departmentId: departmentId };

        $.ajax({

            type: "POST",
            url: '/Course/GetTeachersByDepartmentId',
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(jasonData),
            dataType: "json",
            success: function (data) {
                console.log(data);
                $("#teacherDropDownList").append('<option value=0>--Select--</option>');
                $.each(data, function (key, value) {

                    $("#teacherDropDownList").append('<option value=' + value.Id + '>' + value.Name + '</option>');

                });
            },

        });


        $("#courseCodeDropDownList").empty();
        var jasonData = { departmentId: departmentId };

        $.ajax({

            type: "POST",
            url: '/Course/GetCoursesByDepartmentId',
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(jasonData),
            dataType: "json",
            success: function (data) {
                $("#courseCodeDropDownList").append('<option value=0>--Select</option>');
                $.each(data, function (key, value) {

                    $("#courseCodeDropDownList").append('<option value=' + value.Id + '>' + value.Code + '</option>');

                });
            },

        });
        ResetValue();
        return false;
    });

    $("#teacherDropDownList").change(function () {
        $("#creditTextBox").val("");
        $("#remainingCreditTextBox").val("");
        var teacherSelected = $("#teacherDropDownList").val();
        var jsonData = { TeacherId: teacherSelected };
        $.ajax({
            type: "POST",
            url: '/Course/GetTeacherById',
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(jsonData),
            dataType: "json",
            success: function (data) {



                $("#creditTextBox").val(data[0].TotalCredit);
                $("#remainingCreditTextBox").val(data[0].RemainingCredit);

            },

        });

        if (teacherSelected == 0) {
            $("#creditTextBox").val("");
            $("#remainingCreditTextBox").val("");
        }
        return false;
    });

    $("#courseCodeDropDownList").change(function () {

        $("#nameTextBox").val("");
        $("#courseCreditTextBox").val("");
        var courseSelected = $("#courseCodeDropDownList").val();
        var jsonData = { courseId: courseSelected };
        $.ajax({
            type: "POST",
            url: '/Course/GetCourseById',
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(jsonData),
            dataType: "json",
            success: function (data) {



                $("#nameTextBox").val(data[0].Name);
                $("#courseCreditTextBox").val(data[0].Credit);
            },
        });
        if (courseSelected == 0) {
            $("#courseName").val("");
            $("#courseCredit").val("");
        }
        return false;
    });



    return false;
});

function ResetValue() {
    $("#creditTextBox").val("");
    $("#remainingCreditTextBox").val("");
    $("#courseCodeDropDownList").empty();
    $("#teacherDropDownList").empty();
    $("#nameTextBox").val("");
    $("#courseCreditTextBox").val("");





    $("body").on("click", "#assign-btn", function () {
        var remainingCredit = parseFloat($("#remainingCreditTextBox").val(), 10);
        var courseCredit = parseFloat($("#courseCreditTextBox").val(), 10);
        if (remainingCredit - courseCredit < 0) {
            var form = '<div class="form-container"><div class="post-form"><h4 class="confirm-message">' + 'Do you want to assign the course?' + '</h4>' +
                '<div class="form-group">' +
                '<div class="row"><div class="col-sm-offset-2 col-sm-10 btn-container">' +
                '<input type="submit" class="btn btn-info col-sm-5 yes-btn" value="Yes"><button type="button" class="btn btn-danger col-sm-5 no-btn">No</button></div></div></form></div>';
            $("body").append(form);
            $("body").on("click", ".yes-btn", function (event) {
                event.preventDefault();
                $("#signupForm").submit();
            });
            $("body").on("click", ".no-btn", function (event) {
                event.preventDefault();
                $(".form-container").remove();
            });
            return false;
        } else {
            $("#signupForm").submit();
        }
    });
};

