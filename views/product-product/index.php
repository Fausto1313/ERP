<?php

use yii\helpers\Html;
use yii\grid\GridView;


$this->title = 'Product Products';
$this->params['breadcrumbs'][] = $this->title;
?>
<div class="product-product-index">

    <h1><?= Html::encode($this->title) ?></h1>

    <p>
        <?= Html::a('Create Product Product', ['create'], ['class' => 'btn btn-success']) ?>
    </p>

    <?php // echo $this->render('_search', ['model' => $searchModel]); ?>

    <?= GridView::widget([
        'dataProvider' => $dataProvider,
        'filterModel' => $searchModel,
        'columns' => [
            ['class' => 'yii\grid\SerialColumn'],

            'id',
            'message_main_attachment_id',
            'default_code:ntext',
            'active',
            'product_tmpl_id',
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
