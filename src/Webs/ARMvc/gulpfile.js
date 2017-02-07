/// <binding BeforeBuild='min' Clean='clean' />
"use strict";

var gulp = require("gulp"),
    rimraf = require("rimraf");
//concat = require("gulp-concat"),
// cssmin = require("gulp-cssmin"),
// uglify = require("gulp-uglify"),
//sass = require("gulp-sass");//,
// less = require('gulp-less');

var $ = require('gulp-load-plugins')();

var paths = {
    webroot: "./wwwroot/"
};

paths.js = paths.webroot + "js/**/*.js";
paths.minJs = paths.webroot + "js/**/*.min.js";
//paths.scss = paths.webroot + "scss/style.scss";
//paths.less = paths.webroot + "less/style.less";
paths.concatJsDest = paths.webroot + "js/script.min.js";
paths.concatCssDest = paths.webroot + "css/style.css";

gulp.task("clean:js", function (cb) {
    rimraf(paths.concatJsDest, cb);
});

gulp.task("clean:css", function (cb) {
    rimraf(paths.concatCssDest, cb);
});

gulp.task("clean", ["clean:js", "clean:css"]);

gulp.task("min:js", function () {
    return gulp.src([paths.js, "!" + paths.minJs], { base: "." })
        .pipe($.concat(paths.concatJsDest))
        .pipe($.uglify())
        .pipe(gulp.dest("."));
});

gulp.task('sass', function () {
    gulp.src('wwwroot/scss/*.scss')
        .pipe($.sass().on('error', $.sass.logError))
        .pipe(gulp.dest('wwwroot/css'));
});

gulp.task('sass:watch', function () {
    gulp.watch('wwwroot/scss/**/*.scss', ['sass']);
});

// Compiles LESS > CSS 
gulp.task('less', function () {
    return gulp.src('wwwroot/less/style.less')
        .pipe($.less().on('error', function handleError(err) {
            console.error(err.toString());
            this.emit('end');
        }))
        .pipe(gulp.dest('wwwroot/css'));
});
gulp.task('less:watch', function () {
    gulp.watch('wwwroot/less/**/*.less', ['less']);
});

gulp.task("min", ["min:js", "less"]);
