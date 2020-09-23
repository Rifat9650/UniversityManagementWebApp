$(document).ready(function () {
    $("#mahir").hide();
    $("#departmentDropDownList").change(function () {

        //$("#courseDropDownList").empty();
        var departmentId = $("#departmentDropDownList").val();
        var jasonData = { id: departmentId };


        $.ajax({
            type: "POST",
            url: '/AllocateClassRoom/Schedule',
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(jasonData),
            dataType: "json",
            success: function (data) {
                $("#mahir").show();
                //$("#courseDropDownList").append('<option value=0>--Select a Course--</option>');
                $("#tableBody").empty();
                console.log(data);
                $.each(data, function (key, value) {
                    var schedule = "";
                    console.log("________value.ClassRoomAllocations.length", value.ClassRoomAllocations.length);
                    console.log("value.ClassRoomAllocations", value.ClassRoomAllocations);

                    if (value.ClassRoomAllocations.length === 0) {
                        schedule += "<span>Not Scheduled Yet.</span>";
                        console.log("Hahaaaa");
                    }
                    else {
                        for (var s = 0; s < value.ClassRoomAllocations.length; s++) {

                            schedule += "<span>R. No :" + value.ClassRoomAllocations[s].RoomName + "," + value.ClassRoomAllocations[s].Day + "," + value.ClassRoomAllocations[s].FromTime + "-" + value.ClassRoomAllocations[s].ToTime + ";</span><br />";

                        }
                    }

                    $("#tableBody").append('<tr><td>' + value.Code + '</td><td>' + value.Name + '</td><td>' + schedule);

                });
            },

        });
    });
});