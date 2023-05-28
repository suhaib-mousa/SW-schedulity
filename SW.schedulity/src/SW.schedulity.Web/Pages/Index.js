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
    var scheduleModal = $('#scheduleModal');
    var replaceCount;
    var generateSchedule = async function (coursesNo, includeGeneral) {
        $('.change').css('display', 'block');
        scheduleCourse = await ScheduleService.generate(coursesNo, includeGeneral);
        replaceCount = scheduleCourse.restCourses.length;
        var change = '<div class="change pointer"><img src="images/CHANGE.png" style="height:20px;" alt=""></div>';
        if (replaceCount == 0) {
            change = '';
        }
        console.log(scheduleCourse);
        scheduleModal.empty();
        for (var i = 0; i < scheduleCourse.courses.length; i++) {
            scheduleModal.append(
                '<div class="Course-selected">' +
                '<p class="title-co">' + scheduleCourse.courses[i].title + '</p>' +
                '<div class="Hours">' +
                '<img src="images/clock.png" style="height:20px;" alt="">' +
                '<span>' + scheduleCourse.courses[i].numberOfHours + 'h</span>' +
                '</div>' +
                change +
                '</div >'
            );
        }
        $('.change').click(function () {
            var change = $(this).closest('.Course-selected');
            change.remove();
            var replacedIndex = scheduleCourse.restCourses.length - replaceCount;
            replaceCount--;
            if (replaceCount == 0) {
                $('.change').css('display', 'none');
            }
            scheduleModal.append(
                '<div class="Course-selected">' +
                '<p class="title-co">' + scheduleCourse.restCourses[replacedIndex].title + '</p>' +
                '<div class="Hours">' +
                '<img src="images/clock.png" style="height:20px;" alt="">' +
                '<span>' + scheduleCourse.restCourses[replacedIndex].numberOfHours + 'h</span>' +
                '</div>' +
                '</div >'
            );
            scheduleCourse.restCourses[replacedIndex];
        });
    }
    $('#generate').click(async function () {
        var hours = $('#hoursNO').val();
        if (hours < 0 || hours > 18 || hours % 3 != 0) {
            console.log(hours);
            abp.notify.info(
                'the hours number is invalid!'
            );
            return;
        }
        await generateSchedule(hours, $('#include').is(':checked'));
    });
   
   

});