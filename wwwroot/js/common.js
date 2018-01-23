$(document).ready(function(){
    
    InitTinyMCE();

    $('#btnSetApprovalLine').click(function(){
        OpenApprovalLine();
    });
    
    $('#btnSetApprovalLine2').click(function(){
        OpenApprovalLine(2);
    });
});

//tinymce 초기화
function InitTinyMCE() {
    tinymce.init({
        selector: '#tinymce-editor',
        min_height: 500,
        menubar: false,
        branding: true,
        plugins: 'table code image media textcolor colorpicker link lists',
        toolbar: 'formatselect | bold italic underline strikethrough | forecolor backcolor | alignleft aligncenter alignright alignjustify | bullist numlist outdent indent | link image media table | removeformat | code',
        images_upload_url: 'http://localhost:7852',
        language: 'ko_KR'
    });
}

// 결재라인 지정
function OpenApprovalLine(id) {
    if (null == id || "" == id) {
        window.open('/Approval/SetApproval','_blank','width=800,height=680,scrollbars=0,resizable=0');
    } else {
        window.open('/Approval/SetApproval/2','_blank','width=830,height=500,scrollbars=0,resizable=0');
    }
}

// 결재라인 지정 부서정보 가져오기
function GetDepartment() {
    var zNodes = [];
    var setting = {
        check: {
            enable: true, 
            idKey: 'id',
            pIdKey: 'pId',
            isParent: 'isParent'
        }
    };
    
    $.ajax({
        url : '/Approval/GetDepartment',
        dataType : 'json',
        success : function(data){
            
            for(var i = 0; i <= data.length - 1; i++){
                    zNodes[i] = {
                    id : data[i].code,
                    name : data[i].name,
                    isParent: true,
                    open : false,
                    children : []
                }
            }
            // GetEmployeeList(zNodes);
            zTreeObj = $.fn.zTree.init($('#EmployeeList'), setting, zNodes);
        },
        error : function(){
            alert("Error");
        }
    });
}

// 결재라인 지정 부서에 소속된 직원 가져오기
// function GetEmployeeList(zNodes){
//     var zTreeObj;
//     var setting = {
//         check: {
//             enable: true, 
//             idKey: 'id',
//             pIdKey: 'pId',
//             isParent: 'isParent'
//         }
//     };
    
//     $.ajax({
//         url : '/Approval/GetEmployees',
//         dataType : 'json',
//         success : function(data){
//             for(var i = 0; i <= data.length - 1 ; i++){
//                 for(var p = 0; p <= zNodes.length - 1; p++){

//                     if(zNodes[p].code == data[i].departmentCode){
//                         zNodes[p].children.push({
//                             id : data[i].code,
//                             name : data[i].name
//                         });
//                     }
//                 }
//             }

//             zTreeObj = $.fn.zTree.init($('#EmployeeList'), setting, zNodes);
//         }
//     });
// }
