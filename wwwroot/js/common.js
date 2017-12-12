$(document).ready(function(){
    
    InitTinyMCE();

    $('#btnSetApprovalLine').click(function(){
        OpenApprovalLine();
    });
    
});

//tinymce 초기화
function InitTinyMCE() {
    tinymce.init({
        selector: '#tinymce-editor',
        min_height: 400,
        menubar: false,
        branding: true,
        plugins: 'table code image media textcolor colorpicker link lists',
        toolbar: 'formatselect | bold italic underline strikethrough | forecolor backcolor | alignleft aligncenter alignright alignjustify | bullist numlist outdent indent | link image media table | removeformat | code',
        images_upload_url: 'http://localhost:7852',
        language: 'ko_KR'
    });
}

// 결재라인 지정
function OpenApprovalLine() {
    window.open('/Approval/SetApproval','_blank','width=700,height=500,scrollbars=0,resizable=0');
}

// 결재라인 지정 부서정보 가져오기
function GetDepartment() {
    var zNodes = [];
    
    $.ajax({
        url : '/Approval/GetDepartment',
        dataType : 'json',
        success : function(data){
            
            for(var i = 0; i <= data.length - 1; i++){
                    zNodes[i] = {
                    code : data[i].code,
                    name : data[i].name,
                    open : false,
                    children : []
                }
            }
            GetEmployeeList(zNodes);
        },
        error : function(){
            alert("Error");
        }
    });
}

// 결재라인 지정 부서에 소속된 직원 가져오기
function GetEmployeeList(zNodes){
    var zTreeObj;
    var setting = {
        check: {
            enable: true
        }
    };
    
    $.ajax({
        url : '/Approval/GetEmployees',
        dataType : 'json',
        success : function(data){
            for(var i = 0; i <= data.length - 1 ; i++){
                for(var p = 0; p <= zNodes.length - 1; p++){

                    if(zNodes[p].code == data[i].departmentCode){
                        zNodes[p].children.push({
                            code : data[i].code,
                            name : data[i].name
                        });
                    }
                }
            }

            zTreeObj = $.fn.zTree.init($('#EmployeeList'), setting, zNodes);
        }
    });
}