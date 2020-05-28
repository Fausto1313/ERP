<?php

use yii\helpers\Html;

/* @var $this yii\web\View */
/* @var $model app\models\UtmSource */

$this->title = 'Create Utm Source';
$this->params['breadcrumbs'][] = ['label' => 'Utm Sources', 'url' => ['index']];
$this->params['breadcrumbs'][] = $this->title;
?>
<div class="utm-source-create">

    <h1><?= Html::encode($this->title) ?></h1>

    <?= $this->render('_form', [
        'model' => $model,
    ]) ?>

</div>
