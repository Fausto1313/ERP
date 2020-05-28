<?php

use yii\helpers\Html;


$this->title = 'Create Res Country Group';
$this->params['breadcrumbs'][] = ['label' => 'Res Country Groups', 'url' => ['index']];
$this->params['breadcrumbs'][] = $this->title;
?>
<div class="res-country-group-create">

    <h1><?= Html::encode($this->title) ?></h1>

    <?= $this->render('_form', [
        'model' => $model,
    ]) ?>

</div>
