$(function () {
    var l = abp.localization.getResource('schedulity');
    var SectionService = sW.schedulity.sections.section;
    var CourseService = sW.schedulity.courses.course;

    var createSectionModal = new abp.ModalManager(abp.appPath + 'Admin/Sections/CreateModal');
    var editSectionModal = new abp.ModalManager(abp.appPath + 'Admin/Sections/EditModal');
    var deleteSection = function (id) {
        abp.message.confirm(
            l('AreYouSureToDeleteThisSection'), 
            function (result) {
                if (result) { 
                    SectionService.delete(id)
                        .then(function () {
                            abp.notify.info(
                                l('SuccessfullyDeleted')
                            );
                            CreateAccordion();
                        });
                }
            }
        );
    };

    var deleteCourse = function (id) {
        abp.message.confirm(
            l('AreYouSureToDeleteThisCourse'), 
            function (result) {
                if (result) { 
                    CourseService.delete(id)
                        .then(function () {
                            abp.notify.info(
                                l('SuccessfullyDeleted')
                            );
                            CreateAccordion();
                        });
                }
            }
        );
    };

    $("#CreateSection").click(function (e) {
        e.preventDefault();
        createSectionModal.open({});
    });

    $(document).on('click', '.edit-section', function (e) {
        e.preventDefault();
        editSectionModal.open({ id: $(this).closest('.accordion-item').data('section-id') });
    });

    $(document).on('click', '.edit-course', function (e) {
        e.preventDefault();
        editCourseModal.open({ id: $(this).closest('.course-actions').data('course-id') });
    });

    

    $(document).on('click', '.delete-section', function (e) {
        e.preventDefault();
        var sectionId = $(this).closest('.accordion-item').data('section-id');
        deleteSection(sectionId).
            then(function () {
                CreateAccordion();
            });
    });

    $(document).on('click', '.delete-course', function (e) {
        e.preventDefault();
        var courseId = $(this).closest('.course-actions').data('course-id');
        deleteCourse(courseId).
            then(function () {
                CreateAccordion();
            });
    });

    var createCourseModal = new abp.ModalManager(abp.appPath + 'Admin/Courses/CreateModal');
    var editCourseModal = new abp.ModalManager(abp.appPath + 'Admin/Courses/EditModal');

    $(document).on('click', '.create-course', function (e) {
        e.preventDefault();
        createCourseModal.open({ sectionId: $(this).closest('.accordion-item').data('section-id') });
    });

    var CreateAccordion = async function () {
        var getSections = function () {
            return new Promise(function (resolve, reject) {
                $.ajax({
                    url: '/api/app/section',
                    type: 'GET',
                    success: function (response) {
                        resolve(response);
                    },
                    error: function (xhr, status, error) {
                        reject(error);
                    }
                });
            });
        };

        var getCourses = async function () {
            return new Promise(function (resolve, reject) {
                $.ajax({
                    url: '/api/app/course',
                    type: 'GET',
                    success: function (response) {
                        resolve(response);
                    },
                    error: function (xhr, status, error) {
                        reject(error);
                    }
                });
            });
        };

        try {
            var sectionsResponse = await getSections();
            var sections = sectionsResponse.items;

            sections.sort((a, b) => a.order - b.order);

            var dataAccordion = $("#dataAccordion");
            dataAccordion.empty();

            for (var i = 0; i < sections.length; i++) {
                dataAccordion.append(
                    '<div class="accordion-item" data-section-id="' + sections[i].id + '">' +
                        '<h2 class="accordion-header d-flex align-items-center" id="flush-heading' + i + '">' +
                            '<button class="accordion-button bg-gray my-2 p-4 radius collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#flush-collapse' + i + '" aria-expanded="false" aria-controls="flush-collapse' + i + '">' +
                            '<p><span style="font-size:25px">' + sections[i].title + '</span>.' + sections[i].numberOfHours + 'hr</p>' +
                            '</button>' +
                            '<div class="section-actions pointer p-1">' +
                                '<div class="edit-section"><i class="fas fa-edit"></i></div>' +
                                '<div class="delete-section"><i class="fa fa-trash-o"></i></div>' +
                            '</div>' +
                        '</h2>' +
                        '<div id="flush-collapse' + i + '" class="accordion-collapse collapse" aria-labelledby="flush-heading'  + i + '" data-bs-parent="#accordionFlushExample">' +
                            '<div class="accordion-body">' +
                                '<div class="alert alert-primary" role="alert">There are no courses added yet!</div>' +
                            '</div>' +
                            '<div class="create-course d-flex justify-content-center pointer"><p style="font-size: 40px;" class="fa fa-plus-circle text-center"></p></div>' +
                        '</div>' +
                    '</div>' 
                );
            }
        } catch (error) {
            console.error(error);
        }

        try {
            var coursesResponse = await getCourses();
            var courses = coursesResponse.items;

            await courses.sort((a, b) => a.order - b.order);
            for (var j = 0; j < courses.length; j++) {
                $('[data-section-id="' + courses[j].section.id + '"]').find('.accordion-body')
                    .append(
                    '<div class="d-flex">' +
                    '<div class="Course">' +
                    '<p><span style="font-size:25px">' + courses[j].title + '</span>.' + courses[j].numberOfHours + 'hr</p>' +
                    '</div>' +
                    '<div class="course-actions pointer p-1" data-course-id="' + courses[j].id + '">' +
                    '<div class="edit-course"><i class="fas fa-edit"></i></div>' +
                    '<div class="delete-course"><i class="fa fa-trash-o"></i></div>' +
                    '</div>' + 
                    '</div>' 
                );
                $('[data-section-id="' + courses[j].section.id + '"]').find('.alert').remove();

            }
        
        } catch (error) {
            console.error(error);
        }

    };

    var GetAccordion = async function () {
        try {
            await CreateAccordion();
        } catch (error) {
            console.error(error);
        }
    };

    GetAccordion();

    editSectionModal.onResult(function () {
        CreateAccordion();
    });
    createSectionModal.onResult(function () {
        CreateAccordion();
    });

    createCourseModal.onResult(function () {
        CreateAccordion();
    });
    editCourseModal.onResult(function () {
        CreateAccordion();
    });
});