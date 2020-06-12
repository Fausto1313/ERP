<?php

/* @var $this \yii\web\View */
/* @var $content string */

use app\widgets\Alert;
use yii\helpers\Html;
use yii\bootstrap\Nav;
use yii\bootstrap\NavBar;
use yii\widgets\Breadcrumbs;
use app\assets\AppAsset;
use kartik\sidenav\SideNav;
use kartik\icons\Icon;

AppAsset::register($this);
?>
<?php $this->beginPage() ?>

<!DOCTYPE html>
<html lang="<?= Yii::$app->language ?>">
<head>
    <meta charset="<?= Yii::$app->charset ?>">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <?php $this->registerCsrfMetaTags() ?>
    <title><?= Html::encode($this->title) ?></title>
    <?php $this->head() ?>
</head>
<br></br>

 <header id="header"><!--header-->
        <div class="header_top"><!--header_top-->
            <!--<div class="container">
                <div class="row">
                    <div class="col-sm-6">
                        <div class="contactinfo">
                            <ul class="nav nav-pills">
                                <li><a href="#"><i class="fa fa-company"></i> Reintegración en Servicios de Cómputo S.A. de C.V.</a></li>
                                
                            </ul>
                        </div>
                    </div>
                   
                </div>
            </div>-->
        </div><!--/header_top-->
        
        <div class="header-middle"><!--header-middle-->
            <div class="container">
                <div class="row">
                    <div class="col-sm-4">
                        <div class="logo pull-left">
                            <a href="index"><img src="images/home/RISC.png" alt="Reintegración" width="100" height="100"/></a>                            
                        </div>
                       
                    </div>
                    <div class="col-sm-8">
                        <div class="shop-menu pull-right">
                            <ul class="nav navbar-nav">
                                <li><a href="/index"><i class="fa fa-home"></i> Inicio</a></li>
                                <li><a href="#"><i class="fa fa-star"></i> Servicios</a></li>
                                <li><a href="#"><i class="fa fa-shopping-cart"></i> WIMO</a></li>
                                <li><a href="#"><i class="fa fa-user"></i> Contáctenos</a></li>
                                <li><a href="#"><i class="fa fa-window-restore"></i> Presentaciones</a></li>
                                <li><a href="/login"><i class="fa fa-lock"></i> Login</a></li>
                                
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
        </div><!--/header-middle-->




<body>

 <section id="slider"><!--slider-->
        <div class="container">
            <div class="row">
                <div class="col-sm-12">
                    <div id="slider-carousel" class="carousel slide" data-ride="carousel">
                        <br>
                        <ol class="carousel-indicators">
                            <li data-target="#slider-carousel" data-slide-to="0" class="active"></li>
                            <li data-target="#slider-carousel" data-slide-to="1"></li>
                            <li data-target="#slider-carousel" data-slide-to="2"></li>
                        </ol>
                        
                        <div class="carousel-inner">
                            <div class="item active">
                                <div class="col-sm-6">
                                    <h1>RISC</h1>
                                    <h2>Más de 10 Años deCalidad en el Servicio nos respaldan </h2>
                                    
                                    <button type="button" class="btn btn-default get">Contactenos</button>
                                </div>
                                <div class="col-sm-6">
                                    <img src="images/home/img113.jpg" class="girl img-responsive" alt="" />
                                   
                                </div>
                            </div>


                                                      
                            <div class="item">
                                <div class="col-sm-6">
                                    <h1>RISC</h1>
                                    <h2>Servicios</h2>
                                   
                                    <button type="button" class="btn btn-default get">Conoce más</button>
                                </div>
                                <div class="col-sm-6">
                                    <img src="images/home/soporte-tecnico.jpg" class="girl img-responsive" alt="" />
                                    
                                </div>
                            </div>

                            <div class="item">        
                                <div class="col-sm-6">
                                    <h1>RISC</h1>
                                    <h2>Lansa </h2>
                                    
                                    <button type="button" class="btn btn-default get">Conoce más</button>
                                </div>
                               <br>
                               <br>
                               <br>
                                <div class="col-sm-6">
                                    <img src="images/home/574.png" class="girl img-responsive" alt="" />
                                   
                                </div>                         
                            </div>

                            <div class="item">
                                <div class="col-sm-6">
                                    <h1>RISC</h1>
                                    <h2>Clientes</h2>
                                    
                                    <button type="button" class="btn btn-default get">Contactanos</button>
                                </div>
                                <div class="col-sm-6">
                                    <img src="images/home/600.jpg" class="girl img-responsive" alt="" />
                                    
                                </div>
                            </div>

                             <div class="item">        
                                <div class="col-sm-6">
                                    <h1>RISC</h1>
                                    <h2></h2>
                                    
                                    <button type="button" class="btn btn-default get">Contactanos</button>
                                </div>
                                <div class="col-sm-6">
                                    <img src="images/home/576.png" class="girl img-responsive" alt="" />
                                   
                                </div>                         
                            </div>
                            
                        </div>
                        
                        <a href="#slider-carousel" class="left control-carousel hidden-xs" data-slide="prev">
                            <i class="fa fa-angle-left"></i>
                        </a>
                        <a href="#slider-carousel" class="right control-carousel hidden-xs" data-slide="next">
                            <i class="fa fa-angle-right"></i>
                        </a>
                    </div>
                    
                </div>
            </div>
        </div>
    </section><!--/slider-->


<!--<?php $this->beginBody() ?>

<div class="wrap">
    
    <?php
   NavBar::begin([
        //'brandLabel' => Yii::$app->name,
        'brandLabel' => Html::img('./web/images/home/RISC.png'),
        'brandLabel' => 'ERP RISC',
        'brandUrl' => Yii::$app->homeUrl,
        'options' => [
            'class' => 'navbar-inverse navbar-fixed-top',
        ],
    ]);

    echo Nav::widget([
        'options' => ['class' => 'navbar-nav navbar-right'],
        'items' => [
            //['label'] => '<img src="./web/assets/img/RISC.png">',
            ['label' => 'Inicio', 'url' => ['/site/index']],
           
            Yii::$app->user->isGuest ? (
                ['label' => 'Login', 'url' => ['/site/login']]
            ) : (
                '<li>'
                . Html::beginForm(['/site/logout'], 'post')
                . Html::submitButton(
                    'Logout (' . Yii::$app->user->identity->username . ')',
                    ['class' => 'btn btn-link logout']
                )
                . Html::endForm()
                . '</li>'
            )
        ],
    ]);
    NavBar::end();
    ?>-->




    <div class="container">
    <?= Breadcrumbs::widget([
            'links' => isset($this->params['breadcrumbs']) ? $this->params['breadcrumbs'] : [],
        ]) ?>
        <?= Alert::widget() ?>
        <div class="col-xs-5 col-sm-4 col-lg-3" >
        
        <?php 
             echo SideNav::widget([      

                'type' => SideNav::TYPE_DEFAULT,
                'heading' => 'ERP RISC',
                
                'items' => [
                    [
                        'url' => Yii::$app->homeUrl,
                        'label' => 'Inicio',
                        'icon' => 'home',
                    ],
                    [
                        'url' => 'http://localhost:8080/index.php?r=site%2Fabout',
                        'label' => 'Acerca de',
                        'icon' => 'question-sign',
                    ],
                    [
                        'label' => 'Módulo CRM',
                        'icon' => 'user',
                        'url' => 'http://localhost:8080/index.php?r=crm-lead%2Findex',
                        'items' => [
                            ['label' => 'Clientes', 'icon'=>'user', 'url'=>'http://localhost:8080/index.php?r=res-partner%2Findex'],
                            ['label' => 'Oportunidades', 'icon'=>'user', 'url'=>'http://localhost:8080/index.php?r=crm-lead%2Findex'],
                            ['label' => 'Presupuesto', 'icon'=>'user', 'url'=>'http://localhost:8080/index.php?r=sale-order%2Findex'],
                            ['label' => 'Equipo de Ventas', 'icon'=>'user', 'url'=>'http://localhost:8080/index.php?r=crm-team%2Findex'],
                        ]
                        
                    ],

                    [
                        'label' => 'Módulo Empleados',
                        'icon' => 'user',
                        'url' => 'http://localhost:8080/index.php?r=res-employed%2Findex',
                        'items' => [
                            ['label' => 'Empleados', 'icon'=>'user', 'url'=>'http://localhost:8080/index.php?r=res-employed%2Findex'],
                            ['label' => 'Departamentos', 'icon'=>'book', 'url'=>'http://localhost:8080/index.php?r=res-employed-department%2Findex'],
                            
                        ]
                        
                    ],

                    [
                        'label' => 'Ventas',
                        'icon' => 'briefcase',
                        'url' => 'http://localhost:8080/index.php?r=product-product%2Findex',
                        'items' => [
                            ['label' => 'Productos', 'icon'=>'product', 'url'=>'http://localhost:8080/index.php?r=product-product%2Findex'],
                            ['label' => 'Categoria de  Productos', 'icon'=>'product', 'url'=>'http://localhost:8080/index.php?r=product-category%2Findex'],
                        ]
                        
                    ],
              
                    
                    [
                        'label' => 'Compañias',
                        'icon' => 'briefcase',
                        'url' =>'http://localhost:8080/index.php?r=res-company%2Findex',
                    ],

                    [
                        'label' => 'Usuarios',
                        'icon' => 'user',
                        'url' =>'http://localhost:8080/index.php?r=res-users%2Findex',
                    ],

                   /* [
                        'label' => 'Help',
                        'icon' => 'question-sign',
                        'items' => [
                            ['label' => 'Contactos', 'icon'=>'info-sign', 'url'=>'http://localhost:8080/index.php?r=res-partner%2Findex'],
                            ['label' => 'Contact', 'icon'=>'phone', 'url'=>'#'],
                        ],
                    ], */
                ],
                
                 ]);
        ?>

         </div> <!-- cierre colxs5-->
         <div class="col-xs-7 col-sm-8 col-lg-9">
          <?= $content ?>
         </div>
     </div> <!-- cierra container -->   
    
</div>
<br>

 <footer id="footer"><!--Footer-->
     
        
        <div class="footer-widget">
            <div class="container">
                <div class="row">
                    <div class="col-sm-4">
                        <div class="single-widget">
                            <h2>NUESTROS PRODUCTOS Y SERVICIOS</h2>
                            <ul class="nav nav-pills nav-stacked">
                                <li><a href="#">Inicio</a></li>
                                <li><a href="#">Soporte de chat en vivo</a></li>
                                
                            </ul>
                        </div>
                    </div>
                    <div class="col-sm-4">
                        <div class="single-widget">
                            <h2>CONTACTESE CON NOSOTROS</h2>
                            <ul class="nav nav-pills nav-stacked">
                                <li><a href="#">Contáctenos</a></li>
                                <li><a href="#">Lista de Correo</a></li>
                                <li><a href="#">Empleos</a></li>
                                <li><a href="#">Presentaciones</a></li>
                                <li><a href="http://helpdesk.addar.mx/contacto_form/">Contacto de Soporte</a></li>
                            </ul>
                        </div>
                    </div>
                    <div class="col-sm-3">
                        <div class="single-widget">
                            <h2>REINTEGRACIÓN EN SERVICIOS DE CÓMPUTO, S.A. DE C.V.</h2>
                             <p>Somos un equipo de profesionales, nuestra meta es ayudar a mejorar los procesos, a través de las integraciones que ofrecemos, con productos disruptivos.
                Construimos grandes productos para solucionar y optimizar, problemas de negocio, en la pequeña y mediana empresa. </p>

                <p>Aviso de Privacidad</p>
                            
                        </div>
                    </div>
                   
                    
                    
                </div>
            </div>
        </div>
        
        
        
    </footer><!--/Footer-->
<footer class="footer">
    <div class="container">
        <p class="pull-left">&copy; Reintegración en Servicios de Cómputo S.A. de C.V. <?= date('Y') ?></p>

        <p class="pull-right"><?= Yii::powered() ?></p>
    </div>
</footer>

<?php $this->endBody() ?>
</body>
</html>
<?php $this->endPage() ?>