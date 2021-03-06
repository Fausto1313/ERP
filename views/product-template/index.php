<?php

use yii\helpers\Html;
use yii\grid\GridView;


$this->title = 'Productos';
$this->params['breadcrumbs'][] = $this->title;
?>
<div class="product-template-index">

    <h1><?= Html::encode($this->title) ?></h1>

    <p>
        <?= Html::a('Crear Producto', ['create'], ['class' => 'btn btn-success']) ?>
    </p>

    <?php // echo $this->render('_search', ['model' => $searchModel]); ?>

    <?= GridView::widget([
        'dataProvider' => $dataProvider,
        'filterModel' => $searchModel,
        'columns' => [
            ['class' => 'yii\grid\SerialColumn'],

            //'id',
            'name',
            'type',
            'categ_name',
            'active',
            //'barcode:ntext',
            //'combination_indices:ntext',
            //'volume',
            //'weight',
            //'can_image_variant_1024_be_zoomed',
            //'create_uid',
            //'create_date',
            //'write_uid',
            //'write_date',
            //'trial375',

            ['class' => 'yii\grid\ActionColumn'],
        ],
    ]); ?>


</div>
