<?php

use yii\helpers\Html;
use yii\grid\GridView;
use yii\helpers\ArrayHelper;
use yii\jui\DatePicker;

$this->title = 'Empleados';
$this->params['breadcrumbs'][] = $this->title;
?>
<div class="res-employed-index">

    <h1><?= Html::encode($this->title) ?></h1>

    <p>
        <?= Html::a('Crear Empleado', ['create'], ['class' => 'btn btn-success']) ?>
    </p>

    <?php // echo $this->render('_search', ['model' => $searchModel]); ?>

    <?= GridView::widget([
        'dataProvider' => $dataProvider,
        'filterModel' => $searchModel,
        'columns' => [
            ['class' => 'yii\grid\SerialColumn',
            'contentOptions' => ['style' => 'width: 30px;','height: px', 'class' => 'text-center'],],
            
            //'id',
            //'idscrapy_data',
            //'header_data:ntext',
            //'body_data:ntext',
            
            
            //'Id',
            'Id_Comp',
            'N_Empleado',
            'E_Apellidos',
            'E_Nomina',
            //'F_Creacion',
    
            //'ID_Partner',

            ['class' => 'yii\grid\ActionColumn'],
        ],
    ]); ?>


</div>
