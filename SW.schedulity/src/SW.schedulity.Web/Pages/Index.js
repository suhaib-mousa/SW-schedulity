$(function () {
    var UserCourseService = sW.schedulity.userCourses.userCourse;

    var renderPage = function () {
        var userCoursesCount = $('#user-courses-count');
        $.ajax({
            url: '/api/app/user-course/user-list',
            type: 'GET',
            success: function (response) {
                userCoursesCount.empty();
                userCoursesCount.append(response.length);
            }
        });

        var pathElement = $('.circle');
        var percentage = $('#progress-as-percentage');
        $.ajax({
            url: '/api/app/user-course/progress-as-percentage',
            type: 'POST',
            success: function (response) {
                percentage.empty();
                percentage.append(response + '%');
                pathElement.attr('stroke-dasharray', response + ', 100');
            }
        });

        var checkboxes = $('.course-check');

        checkboxes.each(function () {
            var checkbox = $(this);
            var courseId = checkbox.data('course-id');
            $.ajax({
                url: '/api/app/user-course/is-checked/'+courseId,  
                method: 'POST',
                data: { courseId: courseId },
                success: function (result) {
                    if (result === true) {
                        checkbox.prop('checked', true); 
                    }
                }
            });
        });
    }

    $(document).ready(async function () {
        $('.course-check').change(async function () {
            var courseId = $(this).data('course-id');
            if ($(this).is(':checked')) {
                $(this).prop('checked', true); 
                await UserCourseService.createIfNotExist(courseId);
                renderPage();
            } else {
                $(this).prop('checked', false); 
                await UserCourseService.delete(courseId);
                renderPage();
            }
        });
    });

    renderPage();

    var ScheduleService = sW.schedulity.schedules.schedule;
    var scheduleCourse;
    
    var generateSchedule = function (coursesNo, includeGeneral) {
        scheduleCourse = ScheduleService.generate(coursesNo, includeGeneral);
        console.log(scheduleCourse);
    }
    $('#generate').click(function () {
        var hours = $('#hoursNO').val();
        if (hours < 0 || hours > 18 || hours % 3 != 0) {
            console.log(hours);
            abp.notify.info(
                'the hours number is invalid!'
            );
            return;
        }
        generateSchedule(hours, $('#include').is(':checked'));
    });
});
