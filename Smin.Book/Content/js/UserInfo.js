
$(function () {
    var userInfoJS = new UserInfoJS();
})

class UserInfoJS {
    btnUpdateState = 0;
    btnUpateHtml = "<i class='fas fa-edit mr-1'></i>Cập nhật thông tin";
    btnSaveHtml = "<i class='fas fa-save mr-1'></i>Lưu";
    constructor() {
        this.loadInfo();
        this.initEvent();
    }

    initEvent() {
        $("#btnUpdateUser").click(this.btnUpdateOnClick.bind(this));
        $("#btnConfirmPassword").click(this.btnConfirmPasswordOnClick.bind(this));
    }

    btnUpdateOnClick() {
        if (this.btnUpdateState == 0) {
            this.startEdit();
            $("#btnUpdateUser")
                .html(this.btnSaveHtml)
                .removeClass("btn-primary")
                .addClass("btn-success");
            this.btnUpdateState = 1;
        } else {
            this.saveEdit();
        }
    }

    startEdit() {
        $("#txtFullName").prop('disabled', false);
        $("#txtBirthday").prop('disabled', false);
        $("#txtGender").prop('disabled', false);
        $("#txtMobile").prop('disabled', false);
        $("#txtAddress").prop('disabled', false);
        $("#txtEmail").prop('disabled', false);
        $("#txtCmtnn").prop('disabled', false);
    }

    saveEdit() {
        // 1.show pop up confirm by password
        this.showForm();
    } 

    btnConfirmPasswordOnClick() {
        var self = this;
        // 1. get info then wrap to a object userInfo
        var userInfo = {
            USER_LOGIN: $("#txtUserLogin").val(),
            PASSWORD: $("#txtConfirmPassword").val(),
            FULL_NAME: $("#txtFullName").val(),
            BIRTH_DAY: $("#txtBirthday").val(),
            GENDER: $("#txtGender").val(),
            MOBILE: $("#txtMobile").val(),
            ADDRESS: $("#txtAddress").val(),
            EMAIL: $("#txtEmail").val(),
            CMTNN: $("#txtCmtnn").val()
        }
        // 2. call API with method is PUT
        $.ajax({
            url: "api/user",
            method: "POST",
            data: userInfo
        }).done(function (res) {
            if (res == "success") {
                // 4. if cussess then change html btn, change state btn, hide form
                //$("#btnUpdateUser")
                //    .html(this.btnUpdateHtml)
                //    .removeClass("btn-success")
                //    .addClass("btn-primary");
                //this.btnUpdateState = 0;
                //self.hideForm();
                location.reload();
            } else {
                $("#inputNotice").html(res);
            }
        }).fail(function (res) {
            console.log(res);
        })
    }

    loadInfo() {
        var self = this;
        // 1. Call Ajax to get data
        $.ajax({
            url: "api/user",
            method: "GET"
        }).done(function (res) {
            self.rawUserInfo(res);
        }).fail(function (res) {
            console.log(res);
        })

        // 2. Generate to Html

        // 3. Render to UI
    }

    rawUserInfo(userInfo) {
        $("#txtUserLogin").val(userInfo['USER_LOGIN']);
        $("#txtPassword").val(userInfo['PASSWORD']);
        $("#txtFullName").val(userInfo['FULL_NAME']);
        $("#txtBirthday").val(userInfo['BIRTH_DAY']);
        $("#txtGender").val(userInfo['GENDER']);
        $("#txtMobile").val(userInfo['MOBILE']);
        $("#txtAddress").val(userInfo['ADDRESS']);
        $("#txtEmail").val(userInfo['EMAIL']);
        $("#txtCmtnn").val(userInfo['CMTNN']);
    }

    showForm() {
        $(".modal").modal("show");
    }

    hideForm() {
        $(".modal").modal("hide");
    }
}