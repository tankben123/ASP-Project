/// <reference path = "../lib/jquery/jquery.min.js"/>
$(document).ready(function () {
    $(frm).submit(function (ev) {
        ev.preventDefault();

        var f = $('input[name="f"]')[0].files[0];
        if (!f) {
            alert("Vui lòng chọn file!");
            return;
        }

        var fd = new FormData();
        fd.append('f', f);

        $.ajax({
            method: 'POST',
            url: '/Upload/Ajax', // ← đúng route controller/action
            data: fd,
            contentType: false,
            processData: false,
            success: function (d) {
                if (d != 'error') {
                    $(exModal).modal('hide');
                    $('#rs').append(`
                        <tr>
                            <td>${d.id}</td>
                            <td>${d.originalName}</td>
                            <td><img src="/Images/${d.url}" width="100" alt="${d.originalName}" /></td>
                            <td>${d.type}</td>
                            <td>${d.size}</td>
                        </tr>
                    `);
                } else {
                    console.warn("Phản hồi lỗi:", d);
                }
            },
            error: function (xhr) {
                console.error("Lỗi upload:", xhr.status, xhr.responseText);
            }
        });
    });
});
