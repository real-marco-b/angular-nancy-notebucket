var ts = require('gulp-typescript');
var gulp = require('gulp');
var clean = require('gulp-clean');
var inlineNg2Template = require('gulp-inline-ng2-template');

var destPath = '../artifacts/Content/';

// Delete the dist directory
gulp.task('clean', function() {
    return gulp.src(destPath)
        .pipe(clean());
});

//Moves Angular 2 & related scripts to wwwroot folder of ASP.NET Core app
gulp.task("scriptsNStyles", () => {
    gulp.src([
            'es6-shim/es6-shim.min.js',
            'systemjs/dist/system-polyfills.js',
            'systemjs/dist/system.src.js',
            'reflect-metadata/Reflect.js',
            'rxjs/**',
            'zone.js/dist/**',
            '@angular/**',
            'jquery/dist/jquery.*js',
            'bootstrap/dist/js/bootstrap*.js',
        ], {
            cwd: "node_modules/**"
        })
        .pipe(gulp.dest("../artifacts/Content/libs"));

    gulp.src([
        'node_modules/bootstrap/dist/css/bootstrap.css'
    ]).pipe(gulp.dest('../artifacts/Content/libs/css'));

    gulp.src([
        'src/*.html'
    ]).pipe(gulp.dest('../artifacts/Content/appScripts'));

    gulp.src([
        'wwwroot/*.css',
        'wwwroot/*.js'
    ]).pipe(gulp.dest('../artifacts/Content/'));

    gulp.src([
        'wwwroot/fonts/*'
    ]).pipe(gulp.dest('../artifacts/Content/fonts/'));

    gulp.src([
        'wwwroot/assets/*'
    ]).pipe(gulp.dest('../artifacts/Content/assets/'));

    gulp.src([
        'wwwroot/*.html'
    ]).pipe(gulp.dest('../artifacts/Content/'));
});

//ts - task to transpile 
var tsProject = ts.createProject('src/tsconfig.json');
gulp.task('ts', function(done) {    
    var tsResult = gulp.src([
            "src/**/*.ts"
        ])
        .pipe(inlineNg2Template({ base: '/src' }))
        .pipe(tsProject(ts.reporter), undefined, ts.reporter.fullReporter());
    return tsResult.js.pipe(gulp.dest('../artifacts/Content/appScripts'));
});

gulp.task('watch', ['watch.ts']);

gulp.task('watch.ts', ['ts'], function() {
    return gulp.watch('src/*.ts', ['ts']);
});

gulp.task('default', ['scriptsNStyles', 'watch']);