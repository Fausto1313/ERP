<?php

use yii\helpers\Html;


$this->title = 'Create Product Product';
$this->params['breadcrumbs'][] = ['label' => 'Product Products', 'url' => ['index']];
$this->params['breadcrumbs'][] = $this->title;
?>
<div class="product-product-create">

    <h1><?= Html::encode($this->title) ?></h1>

    <?= $this->render('_form', [
        'model' => $model,
    ]) ?>

</div>
