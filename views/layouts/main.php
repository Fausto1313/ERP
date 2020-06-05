<?php

/* @var $this \yii\web\View */
/* @var $content string */
//se aplico cambios al main

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
<body>
<?php $this->beginBody() ?>

<div class="wrap">
    
    <?php
    NavBar::begin([
        //'brandLabel' => Yii::$app->name,
        'brandLabel' => Html::img('./web/assets/img/RISC.png'),
        'brandLabel' => 'ERP RISC',
        'brandUrl' => Yii::$app->homeUrl,
        'options' => [
            'class' => 'navbar-inverse navbar-fixed-top',
        ],
    ]);
    /*En este apartado sedaran de alta las vistas, no es necesario agregar el.php*/

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
    ?>
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
                            ['label' => 'Clientes', 'icon'=>'user', 'url'=>'#'],
                            ['label' => 'Oportunidades', 'icon'=>'user', 'url'=>'#'],
                            ['label' => 'Presupuesto', 'icon'=>'user', 'url'=>'#'],
                            ['label' => 'Equipo de Ventas', 'icon'=>'user', 'url'=>'#'],
                        ]
                        
                    ],
                    [
                        'label' => 'Contactos',
                        'icon' => 'book',
                        'url' => 'http://localhost:8080/index.php?r=res-partner%2Findex',
                    ],
                    [
                        'label' => 'Ventas',
                        'icon' => 'briefcase',
                        'url' => 'http://localhost:8080/index.php?r=crm-team%2Findex',
                    ],
                    [
                        'label' => 'Presupuesto',
                        'icon' => 'stats',
                        'url' =>'http://localhost:8080/index.php?r=sale-order%2Findex',
                    ],
                    [
                        'label' => 'Empleados',
                        'icon' => 'user',
                        'url' =>'http://localhost:8080/index.php?r=res-employed%2Findex',
                    ],
                    [
                        'label' => 'Usuarios',
                        'icon' => 'user',
                        'url' =>'http://localhost:8080/index.php?r=res-users%2Findex',
                    ],
                    [
                        'label' => 'Productos',
                        'icon' => 'briefcase',
                        'url' =>'http://localhost:8080/index.php?r=product-product%2Findex',
                    ],
                    [
                        'label' => 'Categoria de Productos',
                        'icon' => 'stats',
                        'url' =>'http://localhost:8080/index.php?r=product-category%2Findex',
                    ],
                    [
                        'label' => 'Compañias',
                        'icon' => 'briefcase',
                        'url' =>'http://localhost:8080/index.php?r=res-company%2Findex',
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
