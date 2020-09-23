$(function () {

    $("#departmentDropDownList").change(function () {
        $("#courseDropDownList").empty();
        var departmentId = $("#departmentDropDownList").val();
        var jasonData = { id: departmentId };

        $.ajax({
            type: "POST",
            url: '/AllocateClassRoom/GetCourses',
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(jasonData),
            dataType: "json",
            success: function (data) {
                $("#courseDropDownList").append('<option value=0>--Select--</option>');
                $.each(data, function (key, value) {

                    $("#courseDropDownList").append('<option value=' + value.Id + '>' + value.Code + '</option>');

                });
            },

        });


        $("#roomDropDownList").empty();
        var jasonData = { id: departmentId };

        $.ajax({
            type: "POST",
            url: '/AllocateClassRoom/GetRooms',
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(jasonData),
            dataType: "json",
            success: function (data) {
                $("#roomDropDownList").append('<option value=0>--Select--</option>');
                $.each(data, function (key, value) {

                    $("#roomDropDownList").append('<option value=' + value.Id + '>' + value.Name + '</option>');

                });
            },

        });
    });
});